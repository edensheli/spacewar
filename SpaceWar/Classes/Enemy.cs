using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SpaceWar.Classes
{
    /*
    * The enemy class
    */
    class Enemy : EnemyBase
    {
        public int Live { get; set; } // live
        private int dx = 1; // direction on the x-axis ( 0: left, 1: right)
        private static Random rand; //random to attacks
        private bool _makeSound; //if make sound when hit
        private int _limitAttack = 50; // Every so often attack ( 50 * 20 ) / 1000 = 1s so enemy attack every 1 second
        private int _attackCounter; // counter every 20 milisecond

        public Enemy(Canvas gameBoard, double x, double y, int level, bool makeSound) : base(gameBoard, x, y, 5)
        {
            //initialization
            _makeSound = makeSound;
            rand = new Random();
            Live = level;
            _attackCounter = _limitAttack;
            CreateAvatar();
        }
        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var left = Canvas.GetLeft(Avatar); // x of avatar
            var top = Canvas.GetTop(Avatar); // y of avatar

            Move(left);
            Attack(left, top);
            
            //check if hit
            if (Hit() && Live > 0)
            {
                Live -= 1;
                if (_makeSound)
                {
                    //makes sound
                    var sound = new MediaPlayer();
                    sound.Open(new Uri("pack://siteoforigin:,,,/sounds/hit.wav"));
                    sound.Play();
                }
                Avatar.Fill = SetImage();
            }

            //check if die
            if (Live <= 0 || Avatar.Width > 80)
            {
                Explode();
                //20% to send improve ball
                if (rand.Next(1, 100) < 20)
                {
                    //drop improve ball
                    var improve = new ImproveBullet(Canvas.GetLeft(Avatar), Canvas.GetTop(Avatar), GameBoard);
                    GameBoard.Children.Add(improve.Avatar);
                }
            }
        }
        /*
        *set enemy image according to his level
         */
        private ImageBrush SetImage()
        {
            ImageBrush img = new ImageBrush();
            switch (Live)
            {
                case 1:
                    img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemynew.png"));
                    break;
                case 2:
                    img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemy2.png"));
                    break;
                case 3:
                    img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemy3.png"));
                    break;
                case 4:
                    img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemy4.png"));
                    break;
                default:
                    img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemy3.png"));
                    break;
            }
            return img;
        }
        /*
        * create avatar of the enemy
        */
        protected override void CreateAvatar()
        {
            Avatar.Tag = "enemy";
            Avatar.Height = 80;
            Avatar.Width = 80;
            Avatar.Fill = SetImage();
            GameBoard.Children.Add(Avatar);
        }
        /*
        * attack function
        */
        public void Attack(double left, double top)
        {
            _attackCounter--;
            //attack in probability of 0.014 (1.4%) every 20 milliseconds ##(TODO : imporve the probability)##
            if (_attackCounter < 0 && left > 0 && left < GameBoard.ActualWidth - 100)
            {
                new EnemyAttack(GameBoard, left, top);
                _attackCounter = _limitAttack;
            }
                
        }
        /*
        *move function 
        */
        public void Move(double left)
        {
            if (left > GameBoard.ActualWidth - 20)
                dx = 0;

            if (left < 0)
                dx = 1;

            if (dx == 0)
                Canvas.SetLeft(Avatar, left - Speed);

            if (dx == 1)
                Canvas.SetLeft(Avatar, left + Speed);
        }
    }
}
