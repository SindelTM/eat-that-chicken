using System.Windows;
using EatThatChicken.ViewModel;

namespace EatThatChicken.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
        }

    }
}
