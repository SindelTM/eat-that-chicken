namespace EatThatChicken.View
{
    using Common;
    using System.Windows;
    using ViewModel;
    /// <summary>
    /// Interaction logic for EndGameWindow.xaml
    /// </summary>
    public partial class EndGameWindow : Window
    {
        public EndGameWindow(int points)
        {
            InitializeComponent();

            this.DataContext = new EndGameViewModel(this, points);
        }
    }
}
