using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;

namespace SpaceWar.Classes
{

    /*
     * Managing the stages in the game
     */
    class LevelManger
    {
        public int Level { get; set; } // the current level
        private List<EnemyBase> _enemies { get; set; } //a list that holds the enemies in the level
        private Canvas _gameBoard; //game canvas 
        private int _enemyCounter; // counted when to take out a monster * 20 milliseconds (if equal to 30 so (20/1000)*30 =>enemy create every 0.6s  
        private Player _player; // player class 
        private int _enemyiesInLevel; // holds several enemy each stage
        private const int _limit = 30; // the const to initialization _enemyCounter
        private Random rand; // random to the height of the monsters on the screen
        private bool run = true; // is the game run ?
        private int _cashForEnemy = 500, _cashForBoss = 10000;//profit from killing an enemy
        public LevelManger(Canvas gameBoard, Player player)
        {
            //initialization
            rand = new Random();
            Level =1;
            _gameBoard = gameBoard;
            _enemies = new List<EnemyBase>();
            _enemyCounter = _limit;
            _player = player;
            _enemyiesInLevel = 2; // first level
        }
        /*
         * check if level is end
         */
        public bool IsLevelRun()
        {
            if (_enemies.Count <= 0 && _enemyiesInLevel <= 0 && !BossTime())
            {
                Level++;
                _enemyiesInLevel = (int)(Level * 2.5); // calculate how many enemies in a level ##(TODO : better function)##
                _enemyCounter = _limit;
                return false;
            }
            return true;
        }
        /*
         * create enemies on the board
         */
        public void CreateEnemy()
        {
            // check if dead enemies need to be removed
            CheckEnemies();

            //create boss
            if (BossTime() && _enemies.Count < 1)
                _enemies.Add(new Boss(_gameBoard, 0, 0, Level * 5, _player.Settings.Sound));

            //create enemies
            if (!BossTime() && run)
            {
                //decreases every 20 milliseconds
                _enemyCounter -= 1;
                //check if can create more enemies
                if (_enemyCounter < 0 && _enemyiesInLevel > 0)
                {
                    _enemies.Add(new Enemy(_gameBoard, 0, rand.Next(120, 400), EnemyLevel(), _player.Settings.Sound));
                    _enemies.Add(new Enemy(_gameBoard, (int)_gameBoard.ActualWidth - 10, rand.Next(120, 400), EnemyLevel(), _player.Settings.Sound));
                    _enemyiesInLevel -= 2;
                    _enemyCounter = _limit;
                }
            }
        }
        /*
        * // check if dead enemies need to be removed
        */
        private void CheckEnemies()
        {
            for (int i = 0; i < _enemies.Count; i++)
                if (!_gameBoard.Children.Contains(_enemies[i].Avatar))
                {
                    if (_enemies[i] is Boss)
                    {
                        _player.Cash += _cashForBoss;
                        Level++;
                    }
                    else
                        _player.Cash += _cashForEnemy;

                    _enemies.Remove(_enemies[i]);
                }
        }
        /*
         *check if it is boss time
         */
        private bool BossTime()
        {
            return Level % 10 == 0 ? true : false;
        }
        /*
         *decides what level the enemy
         */
        private int EnemyLevel()
        {
            switch (Level)
            {
                case var _ when Level < 10:
                    return 1;
                case var _ when Level < 20:
                    return 2;
                case var _ when Level < 30:
                    return 3;
                case var _ when Level < 40:
                    return 4;
                default:
                    return 5;
            }
        }
        /*
         * stop the level
         */
        public void Stop()
        {
            run = false;
            foreach (var enemy in _enemies)
                enemy.dispatcherTimer.Stop();
        }
        /*
         * start the level
         */
        public void Start()
        {
            run = true;
            foreach (var enemy in _enemies)
                enemy.dispatcherTimer.Start();
        }
    }
}
