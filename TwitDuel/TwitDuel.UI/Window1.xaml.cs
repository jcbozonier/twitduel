using System.Windows;
using StructureMap;
using TwitDuel.Core;

namespace TwitDuel.UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private TweetArena _Arena;

        public Window1()
        {
            InitializeComponent();

            ContainerBootstrapper.BootstrapStructureMap();
            _Arena = ObjectFactory.GetInstance<TweetArena>();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _Arena.ProcessLatestTweets(); 
        }
    }
}
