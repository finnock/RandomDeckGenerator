using System;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using Hearthstone_Deck_Tracker.Hearthstone.Entities;
using System.Xml.Serialization;
using System.IO;
using Hearthstone_Collection_Tracker.ViewModels;
using System.Threading;

namespace Finnock.HDT.Plugins.RandomDeckGenerator
{
    public static class DeckGeneration
    {
        public static Deck NewRandomDeck(string selectedClass, string deckName)
        {
            List<String> cardList = new List<String>();
            List<Card> classCardList = new List<Card>();
            List<Card> nonClassCardList = new List<Card>();
            Card card = new Card();
            
            cardList.Clear();
            cardList.AddRange(CardLists.basic);
            cardList.AddRange(CardLists.basic);
            
            cardList.AddRange(CardLists.levelDruid); cardList.AddRange(CardLists.levelDruid);
            cardList.AddRange(CardLists.levelHunter); cardList.AddRange(CardLists.levelHunter);
            cardList.AddRange(CardLists.levelMage); cardList.AddRange(CardLists.levelMage);
            cardList.AddRange(CardLists.levelPaladin); cardList.AddRange(CardLists.levelPaladin);
            cardList.AddRange(CardLists.levelPriest); cardList.AddRange(CardLists.levelPriest);
            cardList.AddRange(CardLists.levelRogue); cardList.AddRange(CardLists.levelRogue);
            cardList.AddRange(CardLists.levelShaman); cardList.AddRange(CardLists.levelShaman);
            cardList.AddRange(CardLists.levelWarlock); cardList.AddRange(CardLists.levelWarlock);
            cardList.AddRange(CardLists.levelWarrior); cardList.AddRange(CardLists.levelWarrior);
            
            cardList.AddRange(CardLists.naxxWing1); cardList.AddRange(CardLists.naxxWing1);
            cardList.AddRange(CardLists.naxxWing2); cardList.AddRange(CardLists.naxxWing2);
            cardList.AddRange(CardLists.naxxWing3); cardList.AddRange(CardLists.naxxWing3);
            cardList.AddRange(CardLists.naxxWing4); cardList.AddRange(CardLists.naxxWing4);
            cardList.AddRange(CardLists.naxxWing5); cardList.AddRange(CardLists.naxxWing5);
            
            cardList.AddRange(CardLists.brmWing1); cardList.AddRange(CardLists.brmWing1);
            cardList.AddRange(CardLists.brmWing2); cardList.AddRange(CardLists.brmWing2);
            cardList.AddRange(CardLists.brmWing3); cardList.AddRange(CardLists.brmWing3);
            cardList.AddRange(CardLists.brmWing4); cardList.AddRange(CardLists.brmWing4);
            cardList.AddRange(CardLists.brmWing5); cardList.AddRange(CardLists.brmWing5);
            
            cardList.AddRange(CardLists.loeWing1); cardList.AddRange(CardLists.loeWing1);
            cardList.AddRange(CardLists.loeWing2); cardList.AddRange(CardLists.loeWing2);
            cardList.AddRange(CardLists.loeWing3); cardList.AddRange(CardLists.loeWing3);
            cardList.AddRange(CardLists.loeWing4); cardList.AddRange(CardLists.loeWing4);

            cardList.AddRange(RandomDeckGeneratorPlugin.HCTCollection);

            classCardList.Clear();
            nonClassCardList.Clear();
            
            foreach (String strCard in cardList)
            {
                card = new Card(HearthDb.Cards.All[strCard]);
                if (card.PlayerClass == selectedClass)
                {
                    classCardList.Add(card);
                }
                if (card.PlayerClass == null)
                {
                    nonClassCardList.Add(card);
                }
            }
            
            
            Deck newDeck = new Deck();
            
            newDeck.Name = deckName;
            newDeck.Class = selectedClass;
            
            Random random = new Random();
            int r = random.Next(0, 100);
            
            classCardList.Shuffle();
            nonClassCardList.Shuffle();
            
            for (int cardSlot = 1; cardSlot <= 10; cardSlot++)
            {
                newDeck.Cards.Add(classCardList[cardSlot]);
            }
            
            for (int cardSlot = 1; cardSlot <= 20; cardSlot++)
            {
                newDeck.Cards.Add(nonClassCardList[cardSlot]);
            }
            
            // Set the new deck in editing mode
            Hearthstone_Deck_Tracker.API.Core.MainWindow.SetNewDeck(newDeck, true);
            
            // Save the deck
            Hearthstone_Deck_Tracker.API.Core.MainWindow.SaveDeck(true, SerializableVersion.Default, true);
            
            // Select the deck and make it active
            Hearthstone_Deck_Tracker.API.Core.MainWindow.SelectDeck(newDeck, true);

            return newDeck;
        }
    }
}
