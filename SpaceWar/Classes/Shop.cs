using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SpaceWar.Classes
{
    /*
     *the shop class 
     */
    class Shop
    {
        public List<Spaceship> Ships { get; private set; } //list of sapceship
        public Player Player { get;private set; }//player object
        public Shop()
        {
            //initialization
            Player = new Player().Import();
            Ships = new List<Spaceship>();
            //add all ships
            Ships.Add(new Spaceship("rocket1")); 
            Ships.Add(new Spaceship("rocket2"));
            Ships.Add(new Spaceship("rocket3"));
            Ships.Add(new Spaceship("rocket4"));
            Ships.Add(new Spaceship("rocket5"));
            Ships.Add(new Spaceship("rocket6"));
        }

        /*
         *deploy shop function 
         */
        public void Deploy(Grid grid)
        {
            int index = 0;
            foreach (var child in grid.Children)
            {
                if (child is StackPanel stackPanel)
                {
                    if (stackPanel.Uid == "ship") // check if stackpanel is ship container
                    {
                        var img = ((Border)stackPanel.Children[0]).Child as Rectangle; // get the rectangle in the stack panel
                        var imgFromPath = new ImageBrush();
                        imgFromPath.ImageSource = new BitmapImage(new Uri(Ships[index].ImgPath)); 
                        img.Fill = imgFromPath; // set image of ships
                        ((Button)stackPanel.Children[1]).Content = Ships[index].Price.ToString(); // set price on the button

                        //checks which ships the player has
                        foreach (var ship in Player.Ships)
                            if (ship.ID == Ships[index].ID)
                            {
                                ((Border)stackPanel.Children[0]).Background = Brushes.White;
                                ((Button)stackPanel.Children[1]).Content = "Use"; // update button text
                            }

                        //checks which ship the player use
                        if (Player.UseShip.ID == Ships[index].ID)
                            ((Button)stackPanel.Children[1]).Content = "Choosen";// update button text
                        
                        index++;
                    }
                    //update cash label to cash of the player
                    if (stackPanel.Uid == "cash")
                        ((TextBlock)stackPanel.Children[1]).Text = Player.Cash.ToString();
                    
                }
            }
        }
        /*
         * check if user have ship by id
         */
        private bool CheckShip(int id)
        {
            foreach (Spaceship ship in Player.Ships)
                if (ship.Equals(Ships[id]))
                    return true;

            return false;
        }

        /*
         * sell ship function
         */
        public void SellShip(int id)
        {
            //check if user have this ship
            if (CheckShip(id))
                Player.UseShip = Ships[id]; // set ship

            else
            {
                //check if plyaer have enough money
                if (Player.Cash >= Ships[id].Price) 
                {
                    Player.Ships.Add(Ships[id]);
                    Player.Cash -= Ships[id].Price;
                }
                else
                {
                    MessageBox.Show("You dont have enough money");
                }
            }
            Player.Export(); // save player info
        }


    }
}
