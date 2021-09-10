using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SpaceWar.Classes;


namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    ///         public delegate void createGame();

    public partial class Play : UserControl
    {

        Player player;
        public Play()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new GameScreen().Show();
            Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        private void Refresh(object sender, DependencyPropertyChangedEventArgs e)
        {
            player = new Player().Import();
            bestLevel.Text = player.BestLevel.ToString();
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(player.UseShip.ImgPath));
            ship.Fill = img;
        }
    }
}
