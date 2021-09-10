
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    /*
     *  anyone who wants to move should inherit from it
     */
    abstract class CanMove : Update
    {
        public Rectangle Avatar { get;private set; }//rectangle avatar
        public int Speed { get; set; }// speed of the object
        protected Canvas GameBoard { get; private set; } // game board
        protected DispatcherTimer expoldeTimer;// timer to animation of explosion
        public CanMove(Rectangle avatar,double x,double y,int speed,Canvas gameBoard)
        {
            //initialization
            Avatar = avatar;
            Speed = speed;
            GameBoard = gameBoard;
            Canvas.SetLeft(Avatar, x); // set x
            Canvas.SetTop(Avatar, y); // set y
        }
        /*
         * explode function
         */
        protected void Explode()
        {
            expoldeTimer = new DispatcherTimer(); // new dispatcher timer
            expoldeTimer.Interval = TimeSpan.FromSeconds(0.5); // run every 0.5s 
            expoldeTimer.Tick += Destroy;// add destroy function
            expoldeTimer.Start(); // start tick
            ImageBrush img = new ImageBrush(); // create img of explosion
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/boom2.png"));
            Avatar.Fill = img;
            Avatar.Tag = "explode";
            dispatcherTimer.Tick -= dispatcherTimer_Tick; // remove the main timer function
            dispatcherTimer.Stop(); // stop the main timer
        }
        /*
         * destroy function
         */
        protected void Destroy(object sender, EventArgs e)
        {
            GameBoard.Children.Remove(Avatar); // remove avatar from game board
            expoldeTimer.Tick -= Destroy; // remove destroy function
            expoldeTimer.Stop(); // stop the timer
        }
        /*
        * abstract function to create avatar
        */
        abstract protected void CreateAvatar(); 
    }
}
