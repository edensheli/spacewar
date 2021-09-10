using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    /*
    * The attack of boss class
    */
    class BossAttack : CanMove
    {
        private int dx,// direction on the x-axis ( -1: left, 1: right)
            dy; //direction on the y-axis  ( -1: up, 1: down)
        public BossAttack(Canvas gameBoard, double x, double y,int dx,int dy) : base(new Rectangle(), x, y, 10, gameBoard)
        {
            //initialization
            this.dx = dx;
            this.dy = dy;
            CreateAvatar();
        }
        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Move(); 

            //check if out of the screen
            if (Canvas.GetTop(Avatar) > GameBoard.ActualHeight - 100 ||
                Canvas.GetTop(Avatar) < 0 ||
                Canvas.GetLeft(Avatar) < 0 ||
                Canvas.GetLeft(Avatar) > GameBoard.ActualWidth)
                Explode();

            //check if hit the player
            if (Avatar.Width > 40)
                Explode();
        }
        /*
        * create avatar of the attack
        */
        protected override void CreateAvatar()
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemyAtt.png"));
            Avatar.Tag = "enemy";
            Avatar.Height = 40;
            Avatar.Width = 40;
            Avatar.Fill = img;
            GameBoard.Children.Add(Avatar);
        }
        /*
        *move function 
        */
        private void Move()
        {
            if (dx > 0)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) + Speed);
            
            if (dx < 0)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) - Speed);
            
            if (dy > 0)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + Speed);
            
            if (dy < 0)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) - Speed);
            
        }
    }
}
