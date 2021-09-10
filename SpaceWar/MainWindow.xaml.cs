using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace SpaceWar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum ScreensEnum { Home, Play, Shop, Settings }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void GoHome(object sender, RoutedEventArgs e)
        {
            ShowScreen(ScreensEnum.Home);
        }
        private void GoPlay(object sender, RoutedEventArgs e)
        {
            ShowScreen(ScreensEnum.Play);
        }

        private void GoShop(object sender, RoutedEventArgs e)
        {
            ShowScreen(ScreensEnum.Shop);
        }
        private void GoSettings(object sender, RoutedEventArgs e)
        {
            ShowScreen(ScreensEnum.Settings);
        }
        private void ShowScreen(ScreensEnum screenToShow)
        {
            foreach (UserControl screen in Screens.Children)
            {
                screen.Visibility = Visibility.Hidden;
            }
            Screens.Children[(int)screenToShow].Visibility = Visibility.Visible;
        }

    }
}
