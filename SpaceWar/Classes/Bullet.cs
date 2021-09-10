using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    /*
     * The bullet class
    */
    class Bullet :CanMove
    {
        public Bullet(double x,double y,string imgPath,Canvas gameBoard) : base(new Rectangle(),x,y,10,gameBoard)
         {
            //initialization
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(imgPath));
            Avatar.Fill = img;
            CreateAvatar();
        }

        /*
         * execute every 20 milliseconds
         */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //move up
            Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) - Speed);
            //get the rotate transform from avatar
            RotateTransform rotate = Avatar.RenderTransform as RotateTransform;
            //checks if there is no rotation
            if (rotate != null)
                if (rotate.Angle > 0)
                    Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) + 3);// move right if angle is positive
                else
                    Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) - 3);//move left if angle is negative

            //check if out of the screen
            if (Canvas.GetTop(Avatar) < 0)
                Explode();

            //check if is not in the board
            if (!GameBoard.Children.Contains(Avatar))
                Explode();

            //check if hit the enemy
            if (Avatar.Width > 50)
                Explode();
        }
        /*
        * create avatar of the bullet
        */
        protected override void CreateAvatar()
        {
            Avatar.Tag = "bullet";
            Avatar.Height = 50;
            Avatar.Width = 50;
            GameBoard.Children.Add(Avatar);
        }
    }
}
