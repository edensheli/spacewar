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
     * The boss class
     */
    class Boss : EnemyBase
    {
        public int Live { get; set; } // live 
        private int dx = 1; // direction on the x-axis ( 0: left, 1: right)
        private int dy = 0;// direction on the y-axis  ( 0: up, 1: down)
        private static Random rand;//random to attacks
        private bool _makeSound;//if make sound when hit
        private ProgressBar liveProgress;//live indicator 
        public Boss(Canvas gameBoard, double x, double y, int level, bool makeSound) : base(gameBoard, x, y, 7)
        {
            //initialization
            rand = new Random();
            Live = level;
            _makeSound = makeSound;
            CreateAvatar();
            CreateLivePorogress();
        }

        /*
         * execute every 20 milliseconds
         */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var left = Canvas.GetLeft(Avatar); // x of avatar
            var top = Canvas.GetTop(Avatar); // y of avatar

            Move(left,top); 
            Attack(left,top);

            //check if hit
            if (Hit())
            {
                liveProgress.Value -= 1;
                Live -= 1;
                if (_makeSound)
                {
                    //makes sound
                    var sound = new MediaPlayer();
                    sound.Open(new Uri("pack://siteoforigin:,,,/sounds/hit.wav"));
                    sound.Play();
                }
            }

            //check if die
            if (Live <= 0)
            {
                Explode();
                var improve = new ImproveBullet(Canvas.GetLeft(Avatar), Canvas.GetTop(Avatar), GameBoard);
                GameBoard.Children.Add(improve.Avatar);
                GameBoard.Children.Remove(liveProgress);
            }
        }

        /*
         * make attack
         */
        private void Attack(double left, double top)
        {
            //attack in probability of 0.025 (2.5%) every 20 milliseconds ##(TODO : imporve the probability)##
            if (rand.Next(200) < 5)
            {
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, -1, -1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, 1, -1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, -1, 1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, 1, 1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, -1, 0);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, 0, -1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, 0, 1);
                new BossAttack(GameBoard, left + Avatar.Width / 2, top + Avatar.Height / 2, 1, 0);
            }
        }
        /*
         *move function 
         */
        private void Move(double left,double top)
        {

            if (left > GameBoard.ActualWidth - Avatar.Width)
                dx = 0;

            if (left < 0)
                dx = 1;

            if (dx == 0)
                Canvas.SetLeft(Avatar, left - Speed);

            if (dx == 1)
                Canvas.SetLeft(Avatar, left + Speed);

            if (top < 0)
                dy = 1;

            if (top > GameBoard.ActualHeight - Avatar.Height)
                dy = 0;

            if (dy == 0)
                Canvas.SetTop(Avatar, top - Speed);

            if (dy == 1)
                Canvas.SetTop(Avatar, top + Speed);
        }
        /*
         * create live indicator
         */
        private void CreateLivePorogress()
        {
            liveProgress = new ProgressBar();
            liveProgress.Width = 250;
            liveProgress.Height = 50;
            liveProgress.Maximum = Live;
            liveProgress.Value = Live;
            Canvas.SetLeft(liveProgress, (GameBoard.ActualWidth - liveProgress.Width) / 2);
            Canvas.SetTop(liveProgress, 100);
            GameBoard.Children.Add(liveProgress);
        }
        /*
         * create avatar of the boss
         */
        protected override void CreateAvatar()
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/boss1.png"));
            Avatar.Tag = "enemy";
            Avatar.Height = 300;
            Avatar.Width = 300;
            Avatar.Fill = img;
            GameBoard.Children.Add(Avatar);
        }

    }
}

