using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceWar.Classes;

namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Player player;
        public Home()
        {
            InitializeComponent();

            if (!File.Exists("player.json"))
                new Player().Export();
            LoadData();
        }

        private void Refresh(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            player = new Player().Import();
            cash.Text = player.Cash.ToString();
            bestLevel.Text = "Best Level " + player.BestLevel.ToString();
            var img = new BitmapImage(new Uri(player.UseShip.ImgPath));
            ship.Source = img;
            playerName.Text = $"Name: {player.Settings.Name}";
        }
    }
}
