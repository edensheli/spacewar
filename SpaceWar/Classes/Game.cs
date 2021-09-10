using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using SpaceWar.views;
using System.Windows.Input;

namespace SpaceWar.Classes
{
    /*
    * The game class
    */
    class Game : Update
    {
        private Ship _ship; //ship object
        private Canvas _gameBoard; // game board
        private TextBlock _live, _level, _enemy, _shipLevel; // text indicator on the game board
        private Rectangle _attackPrg; // attack pressure indicator
        private GameScreen window; // window of the game
        private Player _player; // player object
        private LevelManger lvl; // level manager object

        public Game(Control control)
        {
            //initialization
            window = (GameScreen)control;
            _player = new Player().Import();
            _live = window.liveText;
            _enemy = window.enemeyText;
            _level = window.levelText;
            _gameBoard = window.gameBoard;
            _shipLevel = window.shipLvelText;
            _ship = new Ship(_player, _gameBoard, control);
            _attackPrg = window.attackPrg;
            control.KeyUp += KeyPressUp;
            lvl = new LevelManger(_gameBoard,_player);
        }

        /*
         *key press realse event
         */
        private void KeyPressUp(object sender, KeyEventArgs e)
        {
            //check if escape key pressed
            if (e.Key == Key.Escape)
            {
                Pause();
                //show dialog if resume to the game
                var result = MessageBox.Show("You want to resume?","Pause",MessageBoxButton.YesNo);
                if (result.ToString() == "Yes")
                    Resume();
                else
                {
                    //save player reaults
                    _player.Export();
                    window.Close();
                    //show main window
                    Application.Current.MainWindow.Visibility = Visibility.Visible;
                }
            }
        }
        /*
        * execute every 20 milliseconds
        */
        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // show result on the screen
            _enemy.Text = "Cash: " + _player.Cash.ToString();
            _live.Text = "Live: " + _ship.Live.ToString();
            _level.Text = "Level: " + lvl.Level.ToString();
            _shipLevel.Text = "Ship Level: " + _ship.Level.ToString();
            _attackPrg.Width = _ship.AttackSlow > 15 ? _ship.AttackSlow : 0; 

            // create levels
            if (lvl.IsLevelRun())
                lvl.CreateEnemy();

            //check if ship die
            if (_ship.Live == 0)
            {
                //update best level of the player
                if (_player.BestLevel < lvl.Level)
                    _player.BestLevel = lvl.Level;
                
                Pause();
                dispatcherTimer.Tick -= dispatcherTimer_Tick; 
                dispatcherTimer.Stop(); // stop timer
                _player.Export(); // save player object
                //show game over dialog
                MessageBoxResult result = MessageBox.Show("You want to play again?", "Game Over!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                window.Close();
                //check if player want begain new game
                if (result.ToString() == "Yes")
                    new GameScreen().Show();
                else
                    Application.Current.MainWindow.Visibility = Visibility.Visible;             
            }
        }

        /*
         *resume game
         */
        public void Resume()
        {
            _ship.dispatcherTimer.Start();
            lvl.Start();
        }
        /**
         * stop game
         */
        public void Pause()
        {
            _ship.dispatcherTimer.Stop();
            lvl.Stop();
        }

        
    }
}
