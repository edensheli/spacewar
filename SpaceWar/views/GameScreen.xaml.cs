using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SpaceWar.Classes;

namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for GameScreen.xaml
    /// </summary>
    public partial class GameScreen : Window
    {
        private Game game;
        private Player player;
        private static MediaPlayer _backgroundMusic = new MediaPlayer();

        public GameScreen()
        {
            InitializeComponent();
            player = new Player().Import();
            game = new Game(this);
            if (player.Settings.Music)
                StartBackgroundMusic();
            Cursor = Cursors.None;
        }

        public static void StartBackgroundMusic()
        {
            _backgroundMusic.Open(new Uri("pack://siteoforigin:,,,/sounds/gameloop.wav"));
            _backgroundMusic.MediaEnded += new EventHandler(BackgroundMusic_Ended);
            _backgroundMusic.Play();
        }

        private static void BackgroundMusic_Ended(object sender, EventArgs e)
        {
            _backgroundMusic.Position = TimeSpan.Zero;
            _backgroundMusic.Play();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _backgroundMusic.Close();
        }
    }
}
