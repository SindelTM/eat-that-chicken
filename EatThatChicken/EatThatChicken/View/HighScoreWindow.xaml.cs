namespace EatThatChicken.View
{
    using EatThatChicken.ViewModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        public HighScoreWindow()
        {
            InitializeComponent();

            this.DataContext = new HighScoreViewModel(this);
        }
    }
}
