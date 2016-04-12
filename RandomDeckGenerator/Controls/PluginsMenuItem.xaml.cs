using System.Windows;
using System.Windows.Controls;

namespace Finnock.HDT.Plugins.RandomDeckGenerator.Controls
{
    /// <summary>
    /// Interaction logic for RandomDeckGeneratorMenu.xaml
    /// </summary>
    public partial class PluginsMenuItem : MenuItem
    {
        public PluginsMenuItem()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            RandomDeckGeneratorPlugin.OpenMenuFlyout();
        }
    }
}
