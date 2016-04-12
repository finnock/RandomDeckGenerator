using System;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Exporting;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using System.Xml.Serialization;
using System.IO;
using Hearthstone_Collection_Tracker.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography;

namespace Finnock.HDT.Plugins.RandomDeckGenerator
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic]
        private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class ShuffleClass
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            CryptoRandom rng = new CryptoRandom();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class RelativePoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public static class HelperClass
    {
        private static Dictionary<String, RelativePoint> ExportPoints = new Dictionary<string, RelativePoint>()
        {
            {"Warrior",      new RelativePoint { X = 0.165, Y = 0.260 } },
            {"Shaman",       new RelativePoint { X = 0.330, Y = 0.260 } },
            {"Rogue",        new RelativePoint { X = 0.495, Y = 0.260 } },
            {"Paladin",      new RelativePoint { X = 0.165, Y = 0.485 } },
            {"Hunter",       new RelativePoint { X = 0.330, Y = 0.485 } },
            {"Druid",        new RelativePoint { X = 0.495, Y = 0.485 } },
            {"Warlock",      new RelativePoint { X = 0.165, Y = 0.700 } },
            {"Mage",         new RelativePoint { X = 0.330, Y = 0.700 } },
            {"Priest",       new RelativePoint { X = 0.495, Y = 0.700 } },
            {"ClassChoose",  new RelativePoint { X = 0.810, Y = 0.820 } },
            {"RecipeCustom", new RelativePoint { X = 0.610, Y = 0.470 } },
            {"RecipeChoose", new RelativePoint { X = 0.670, Y = 0.820 } },
            {"Done",         new RelativePoint { X = 0.935, Y = 0.925 } },
            {"QuestionYes",  new RelativePoint { X = 0.420, Y = 0.600 } }
        };

        public static async void ExportDeck(Deck deck, bool autoFinish = false)
        {
            var export = true;
            var info = new ExportingInfo();
            int pause = 1000;

            if (Config.Instance.ShowExportingDialog)
            {
                var message =
                    $"1) create a new {deck.Class} deck{(Config.Instance.AutoClearDeck ? " (or open an existing one to be cleared automatically)" : "")}.\n\n2) leave the deck creation screen open.\n\n3) do not move your mouse or type after clicking \"export\".";

                if (deck.GetSelectedDeckVersion().Cards.Any(c => c.Name == "Stalagg" || c.Name == "Feugen"))
                {
                    message +=
                        "\n\nIMPORTANT: If you own golden versions of Feugen or Stalagg please make sure to configure\nOptions > Other > Exporting";
                }

                var settings = new Hearthstone_Deck_Tracker.Windows.MessageDialogs.Settings { AffirmativeButtonText = "Export" };
                var result =
                    await
                    Hearthstone_Deck_Tracker.API.Core.MainWindow.ShowMessageAsync("Export " + deck.Name + " to Hearthstone", message, MessageDialogStyle.AffirmativeAndNegative, settings);
                export = result == MessageDialogResult.Affirmative;
            }
            if (export)
            {
                Hearthstone_Deck_Tracker.API.Core.MainWindow.Topmost = false;

                var inForeground = await ExportingHelper.EnsureHearthstoneInForeground(info.HsHandle);
                if (!inForeground)
                    return;

                var controller = await Hearthstone_Deck_Tracker.API.Core.MainWindow.ShowProgressAsync("Creating Deck", "Please do not move your mouse or type.");

                await Task.Delay(pause);
                await ClickOnPoint(info, deck.Class);
                await Task.Delay(pause);
                await ClickOnPoint(info, "ClassChoose");
                await Task.Delay(pause);
                await ClickOnPoint(info, "RecipeCustom");
                await Task.Delay(pause);
                await ClickOnPoint(info, "RecipeChoose");

                await Task.Delay(pause);
                await DeckExporter.Export(deck);
                await controller.CloseAsync();

                if (deck.MissingCards.Any())
                {
                    Hearthstone_Deck_Tracker.Windows.MessageDialogs.ShowMissingCardsMessage(Hearthstone_Deck_Tracker.API.Core.MainWindow, deck);
                }
            }

            if (autoFinish)
            {
                await ClickOnPoint(info, "Done");
                await Task.Delay(pause);
                await ClickOnPoint(info, "QuestionYes");
            }

        }

        public static async void ClickOnPoint(double pointX, double pointY)
        {
            Hearthstone_Deck_Tracker.API.Core.MainWindow.Topmost = false;
            var info = new ExportingInfo();
            var clickPos = new Point((int)Helper.GetScaledXPos(pointX, info.HsRect.Width, info.Ratio),
                                        (int)(pointY * info.HsRect.Height));
            await MouseActions.ClickOnPoint(info.HsHandle, clickPos);
        }

        public static async Task ClickOnPoint(ExportingInfo info, String nameInDictionary)
        {
            Hearthstone_Deck_Tracker.API.Core.MainWindow.Topmost = false;
            var clickPos = new Point((int)Helper.GetScaledXPos(ExportPoints[nameInDictionary].X, info.HsRect.Width, info.Ratio),
                                        (int)(ExportPoints[nameInDictionary].Y * info.HsRect.Height));
            await MouseActions.ClickOnPoint(info.HsHandle, clickPos);
        }

        public static void ExportCardList(List<String> CardList)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Jan\Desktop\CardList.txt"))
            {
                foreach (String strCard in CardList)
                {
                    Card card = new Card(HearthDb.Cards.All[strCard]);
                    file.WriteLine(strCard + " - " + card.Name + " - " + card.PlayerClass);
                }
            }
        }

        public static void ExportCardList(List<Card> CardList, String FileName)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Jan\Desktop\" + FileName + ".txt"))
            {
                foreach (Card strCard in CardList)
                {
                    file.WriteLine(strCard.Id + " - " + strCard.Name + " - " + strCard.PlayerClass);
                }
            }
        }

        public static void ExportCardList(Dictionary<String, HearthDb.Card> CardList)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Jan\Desktop\DBCardList.txt"))
            {
                foreach (var card in CardList)
                {
                    file.WriteLine(card.Key + " - " + card.Value.Name + " - " + card.Value.Class);
                }
            }
        }

        internal static List<string> GetCollection()
        {
            List<string> collectionList = new List<string>();

            string appDataFolder = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData
            );
            string filePath = Path.Combine(appDataFolder, "HearthstoneDeckTracker\\CollectionTracker\\Collection_Default.xml");

            List<BasicSetCollectionInfo> collection;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer serializer = new XmlSerializer(typeof(List<BasicSetCollectionInfo>));
            // To read the file, create a FileStream.
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            collection = (List<BasicSetCollectionInfo>)serializer.Deserialize(fileStream);

            foreach (CardInCollection cic in collection[0].Cards)
            {
                switch (cic.AmountNonGolden)
                {
                    case 2:
                        collectionList.Add(cic.CardId);
                        collectionList.Add(cic.CardId);
                        break;
                    case 1:
                        collectionList.Add(cic.CardId);
                        break;
                    default:
                        break;
                }
            };

            foreach (CardInCollection cic in collection[1].Cards)
            {
                switch (cic.AmountNonGolden)
                {
                    case 2:
                        collectionList.Add(cic.CardId);
                        collectionList.Add(cic.CardId);
                        break;
                    case 1:
                        collectionList.Add(cic.CardId);
                        break;
                    default:
                        break;
                }
            };

            foreach (CardInCollection cic in collection[2].Cards)
            {
                switch (cic.AmountNonGolden)
                {
                    case 2:
                        collectionList.Add(cic.CardId);
                        collectionList.Add(cic.CardId);
                        break;
                    case 1:
                        collectionList.Add(cic.CardId);
                        break;
                    default:
                        break;
                }
            };

            return collectionList;
        }
    }

    ///<summary>
    /// Represents a pseudo-random number generator, a device that produces random data.
    ///</summary>
    public class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;

        ///<summary>
        /// Creates an instance of the default implementation of a cryptographic random number generator that can be used to generate random data.
        ///</summary>
        public CryptoRandom()
        {
            r = RandomNumberGenerator.Create();
        }

        ///<summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name=”buffer”>An array of bytes to contain random numbers.</param>
        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }

        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        ///<summary>
        /// Returns a random number within the specified range.
        ///</summary>
        ///<param name=”minValue”>The inclusive lower bound of the random number returned.</param>
        ///<param name=”maxValue”>The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        public int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }

        ///<summary>
        /// Returns a nonnegative random number less than the specified maximum
        ///</summary>
        ///<param name=”maxValue”>The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
