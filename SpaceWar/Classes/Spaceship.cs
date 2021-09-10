﻿

namespace SpaceWar.Classes
{
    /*
     *the spaceship struct 
     */
    public struct Spaceship
    {
        public int ID { get; private set; } // id of the ship
        public string Name { get; private set; } //name of the ship
        public string ImgPath { get; private set; }//image of the ship
        public int Price { get; private set; } //price of the ship
        public string BulletPath { get; private set; }//bullet of the ship

        public Spaceship(string name)
        {
            //initialization
            Name = name;
            //set info
            switch (Name)
            {
                case "rocket1":
                    ID = 1;
                    ImgPath = $"pack://application:,,,/images/roketship1.png";
                    BulletPath = $"pack://application:,,,/images/bullet.png";
                    Price = 0;
                    break;
                case "rocket2":
                    ID = 2;
                    ImgPath = $"pack://application:,,,/images/roketship2.png";
                    BulletPath = $"pack://application:,,,/images/laserGreen.png";
                    Price = 50000;
                    break;
                case "rocket3":
                    ID = 3;
                    ImgPath = $"pack://application:,,,/images/shipnew.png";
                    BulletPath = $"pack://application:,,,/images/bulletB.png";
                    Price = 75000;
                    break;
                case "rocket4":
                    ID = 4;
                    ImgPath = $"pack://application:,,,/images/roketship4.png";
                    BulletPath = $"pack://application:,,,/images/bulletP.png";
                    Price = 100000;
                    break;
                case "rocket5":
                    ID = 5;
                    ImgPath = $"pack://application:,,,/images/roketship5.png";
                    BulletPath = $"pack://application:,,,/images/laser.png";
                    Price = 125000;
                    break;
                case "rocket6":
                    ID = 6;
                    ImgPath = $"pack://application:,,,/images/roketship6.png";
                    BulletPath = $"pack://application:,,,/images/bulletA.png";
                    Price = 150000;
                    break;
                default:
                    ID = 0;
                    ImgPath = "";
                    Price = 0;
                    BulletPath = "";
                    break;
            }
        }

        /*
         * check if spaceships is equals
         */
        public override bool Equals(object obj)
        {
            return ((Spaceship)obj).ID == this.ID;
        }
    }
}
