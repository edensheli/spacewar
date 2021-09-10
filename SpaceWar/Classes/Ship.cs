using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace SpaceWar.Classes
{
    /*
    * The ship class
    */
    class Ship : CanMove
    {
        private Player _player; // player object
        public int Live { get; set; } //live
        public int Level { get; set; } //level of ship
        private bool _left, _right, _up, _down; // direction
        private Control _control; // control object
        public int AttackSlow { get; private set; } // attack pressure max
        private int _attackCost = 15; // attack pressure cost
        public Ship(Player player, Canvas gameBoard, Control control)
            : base(new Rectangle(), SystemParameters.PrimaryScreenWidth / 2 - 50, SystemParameters.PrimaryScreenHeight - 200, 20, gameBoard)
        {
            //initialization
            var img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(player.UseShip.ImgPath));
            Avatar.Fill = img;
            CreateAvatar();
            Live = 3;
            Level = 1;
            AttackSlow = 130;
            _player = player;
            _control = control;
            if (_player.Settings.Attack)
                _control.MouseLeftButtonDown += MouseAttack;
            else
                _control.KeyUp += SpaceAttack;

            if (_player.Settings.Move)
                _control.MouseMove += MouseMove;
            else
            {
                _control.KeyUp += StopMove;
                _control.KeyDown += StartMove;
            }


        }

        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // creating a rect to test interaction with the environment
            Rect shipHitBox = new Rect(Canvas.GetLeft(Avatar), Canvas.GetTop(Avatar), Avatar.Width, Avatar.Height);

            //move
            if (_left && Canvas.GetLeft(Avatar) > 0)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) - Speed);

            if (_right && Canvas.GetLeft(Avatar) < GameBoard.ActualWidth - 100)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) + Speed);

            if (_up && Canvas.GetTop(Avatar) > 0)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) - Speed);

            if (_down && Canvas.GetTop(Avatar) < GameBoard.ActualHeight - 100)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + Speed);

            //check if hit
            if (Hit(shipHitBox))
            {
                Live -= 1;
                if (Level > 1)
                    Level--;
            }

            //check if the ship has caught improvement
            if (GetImprove(shipHitBox))
            {
                AttackSlow = 130;
                if (Level < 4)
                    Level++;
            }

            //loading the attack pressure
            if (AttackSlow < 130)
                AttackSlow++;

        }
        /*
         * check if the ship has caught improvement
         */
        private bool GetImprove(Rect shipHitBox)
        {
            foreach (var item in GameBoard.Children.OfType<Rectangle>())
                if ((string)item.Tag == "improve")
                {
                    Rect improveHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (improveHitBox.IntersectsWith(shipHitBox))
                    {
                        GameBoard.Children.Remove(item);
                        return true;
                    }
                }
            return false;
        }
        /*
        *check if hit function
        */
        private bool Hit(Rect shipHitBox)
        {
            foreach (var item in GameBoard.Children.OfType<Rectangle>())
            {
                if ((string)item.Tag == "enemy" || (string)item.Tag == "enemyAttack")
                {
                    Rect enemyHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (enemyHitBox.IntersectsWith(shipHitBox))
                    {
                        item.Width = item.Width + 5;
                        return true;
                    }
                }
            }
            return false;
        }
        /*
         *attack function 
         */
        private void Attack()
        {
            //check if sound is on
            if (_player.Settings.Sound)
            {
                //makes sound
                var sound = new MediaPlayer();
                sound.Open(new Uri("pack://siteoforigin:,,,/sounds/laser.wav"));
                sound.Play();
            }
            if (Level == 1 || Level == 3)
            {
                //create center bullet
                new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3, Canvas.GetTop(Avatar) - Avatar.Height / 2, _player.UseShip.BulletPath, GameBoard);
            }
            if (Level == 2 || Level == 4)
            {
                //create two center bullets
                new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 + 10,
                    Canvas.GetTop(Avatar) - Avatar.Height / 2,
                    _player.UseShip.BulletPath,
                    GameBoard);
                new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 - 10,
                    Canvas.GetTop(Avatar) - Avatar.Height / 2,
                    _player.UseShip.BulletPath,
                    GameBoard);
            }
            if (Level == 3 || Level == 4)
            {
                //create two side bullets
                new Bullet
                    (Canvas.GetLeft(Avatar) + Avatar.Width / 3 + 10,
                    Canvas.GetTop(Avatar) - Avatar.Height / 2,
                    _player.UseShip.BulletPath, GameBoard)
                    .Avatar.RenderTransform = new RotateTransform(15);
                new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 - 10,
                    Canvas.GetTop(Avatar) - Avatar.Height / 2 + 7,
                    _player.UseShip.BulletPath, GameBoard)
                    .Avatar.RenderTransform = new RotateTransform(-15);
            }
            AttackSlow -= _attackCost; // down attack pressure
        }

        private void MouseAttack(object sender, MouseButtonEventArgs e)
        {
            if (AttackSlow > _attackCost)
                Attack();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            var p = e.GetPosition(GameBoard);
            Canvas.SetLeft(Avatar, p.X - Avatar.Width / 2);
            Canvas.SetTop(Avatar, p.Y - Avatar.Height / 2);
        }

        /*
         * key press down event
         */
        private void StartMove(object sender, KeyEventArgs e)
        {
            Move(e, true);
        }
        /*
        * key realse event
        */
        private void StopMove(object sender, KeyEventArgs e)
        {
            Move(e, false);
        }
        private void SpaceAttack(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                if (AttackSlow > _attackCost)
                    Attack();
        }
        /*
         * move function
         */
        private void Move(KeyEventArgs e, bool isMove)
        {
            if (e.Key == Key.Left)
                _left = isMove;

            if (e.Key == Key.Right)
                _right = isMove;

            if (e.Key == Key.Up)
                _up = isMove;

            if (e.Key == Key.Down)
                _down = isMove;
        }
        /*
        * create avatar of the ship
        */
        protected override void CreateAvatar()
        {
            Avatar.Tag = "ship";
            Avatar.Height = 100;
            Avatar.Width = 80;
            GameBoard.Children.Add(Avatar);
        }
    }
}
