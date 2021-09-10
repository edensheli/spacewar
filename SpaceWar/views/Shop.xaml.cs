﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : UserControl
    {
        Classes.Shop shop;
        public Shop()
        {
            InitializeComponent();
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var shipID = int.Parse(btn.Uid);
            shop.SellShip(shipID);
            shop.Deploy(shopGrid);            
        }


        private void Refresh(object sender, DependencyPropertyChangedEventArgs e)
        {
            shop = new Classes.Shop();
            shop.Deploy(shopGrid);
        }
    }
}
