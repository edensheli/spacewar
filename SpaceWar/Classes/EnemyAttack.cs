using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    class EnemyAttack : CanMove
    {
        /*
        * The attack of enemy class
        */
        public EnemyAttack(Canvas gameBoard,double x,double y) : base(new Rectangle(),x,y,6,gameBoard)
        {
            //initialization
            CreateAvatar();
        }
        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + Speed); // move down
            
            //check if out of the screen
            if (Canvas.GetTop(Avatar) > GameBoard.ActualHeight - 100)
                Explode();

            //check if hit ship
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
    }
}
