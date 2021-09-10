using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    /**
    *  enemy base abstract class
    */
    abstract class EnemyBase : CanMove
    {
        public EnemyBase(Canvas gameBoard, double x, double y, int speed) : base(new Rectangle(), x, y, speed, gameBoard) { }

        //check if hit function
        protected bool Hit()
        {
            // creating a rect to test interaction with the environment
            Rect enemyHitBox = new Rect(Canvas.GetLeft(Avatar), Canvas.GetTop(Avatar), Avatar.Width, Avatar.Height);
            foreach (var item in GameBoard.Children.OfType<Rectangle>())
            {
                //search for bullets
                if ((string)item.Tag == "bullet")
                {
                    //create rect for bullet
                    Rect bulletHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    //check if hit
                    if (bulletHitBox.IntersectsWith(enemyHitBox))
                    {
                        item.Width += 5;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
