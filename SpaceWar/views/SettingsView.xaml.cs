using SpaceWar.Classes;
using System.Windows;
using System.Windows.Controls;
using SpaceWar.Theme;

namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        Player player;
        public SettingsView()
        {
            InitializeComponent();
            player = new Player().Import();
            music.IsChecked = player.Settings.Music;
            sound.IsChecked = player.Settings.Sound;
            move.IsChecked = player.Settings.Move;
            attack.IsChecked = player.Settings.Attack;
            music.Content = (bool)music.IsChecked ? "ON" : "OFF";
            sound.Content = (bool)sound.IsChecked ? "ON" : "OFF";
            attack.Content = (bool)attack.IsChecked ? "Mouse" : "Keyboard";
            move.Content = (bool)move.IsChecked ? "Mouse" : "Keyboard";
            playerName.Text = player.Settings.Name;
        }


        private void MusicOn(object sender, RoutedEventArgs e)
        {
            player.Settings.Music = true;
           player.Export();
            ((CheckBox)sender).Content = "ON";
        }

        private void SoundOn(object sender, RoutedEventArgs e)
        {
            player.Settings.Sound = true;
            player.Export();
            ((CheckBox)sender).Content = "ON";
        }

        private void SoundOff(object sender, RoutedEventArgs e)
        {
            player.Settings.Sound = false;
            player.Export();
            ((CheckBox)sender).Content = "OFF";
        }

        private void MusicOff(object sender, RoutedEventArgs e)
        {
            player.Settings.Music = false;
            player.Export();
            ((CheckBox)sender).Content = "OFF";
        }

        private void nameChange(object sender, TextChangedEventArgs e)
        {
            playerName.Text = FirstLetterToUpper(playerName.Text);
            playerName.CaretIndex = playerName.Text.Length;
            player.Settings.Name = playerName.Text;
            player.Export();
            
        }

        private void MoveWithMouse(object sender, RoutedEventArgs e)
        {
            player.Settings.Move = true;
            player.Export();
            ((CheckBox)sender).Content = "Mouse";
        }

        private void AttackWithMouse(object sender, RoutedEventArgs e)
        {
            player.Settings.Attack = true;
            player.Export();
            ((CheckBox)sender).Content = "Mouse";
        }

        private void AttackWithKeyboard(object sender, RoutedEventArgs e)
        {
            player.Settings.Attack = false;
            player.Export();
            ((CheckBox)sender).Content = "Keyboard";
        }

        private void MoveWithKeyboard(object sender, RoutedEventArgs e)
        {
            player.Settings.Move = false;
            player.Export();
            ((CheckBox)sender).Content = "Keyboard";
        }

        private string FirstLetterToUpper(string name)
        {
            if (name.Length > 1)
                return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();

            return name.ToUpper();
        }
    }
}
