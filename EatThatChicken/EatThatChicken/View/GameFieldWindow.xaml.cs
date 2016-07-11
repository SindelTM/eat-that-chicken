namespace EatThatChicken.View
{
    using EatThatChicken.ViewModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for GameFieldWindow.xaml
    /// </summary>
    public partial class GameFieldWindow : Window
    {
        public GameFieldWindow()
        {
            InitializeComponent();
            this.DataContext = new GameFieldViewModel(this);
        }
    }
}
