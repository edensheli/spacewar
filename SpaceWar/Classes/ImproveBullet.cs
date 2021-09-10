using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;

namespace SpaceWar.Classes
{
    /*
     * The improve ball class
     */
    class ImproveBullet : CanMove
    {
        public ImproveBullet(double x,double y,Canvas gameBoard):base(new Rectangle(),x,y,3,gameBoard)
        {
            //initialization
            CreateAvatar();
        }
        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // move down
            Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + Speed);

            //check if out of the screen
            if (Canvas.GetTop(Avatar) > GameBoard.ActualHeight)
                RemoveImprove();

            //check if game board contain the avatar
            if (!GameBoard.Children.Contains(Avatar))
                RemoveImprove();      
        }
        /*
         *remove improve and stop timer
         */
        private void RemoveImprove()
        {
            GameBoard.Children.Remove(Avatar);
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();
        }
        /*
        * create avatar of the improve ball
        */
        protected override void CreateAvatar()
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/improveBall.png"));
            Avatar.Tag = "improve";
            Avatar.Height = 50;
            Avatar.Width = 50;
            Avatar.Fill = img;
        }

    }
}
