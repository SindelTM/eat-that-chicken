using EatThatChicken.Common;
using System.Windows.Input;
using EatThatChicken.View;

namespace EatThatChicken.ViewModel
{
    class MainViewModel
    {
        private MainWindow mainWindow;

        //field startCommand,exitCommand-btnStart,btnExit
        private CommandBase startCommand;
        private CommandBase exitCommand;

        //constructor 
        public MainViewModel(MainWindow window)
        {
            mainWindow = window;
        }

        //property btnStart,btnExit
        public ICommand StartCommand
        {
            get
            {
                if (this.startCommand == null)
                {
                    this.startCommand = new CommandBase(this.StartGame, this.CanExecuteStartCommand);
                }

                return this.startCommand;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new CommandBase(this.ExitGame, this.CanExecuteExitCommand);
                }
                return this.exitCommand;
            }
        }

        //methods for opening/closing windows btnStart,btnExit
        private void StartGame(object param)
        {
            GameFieldWindow gameFieldWindow = new GameFieldWindow();
            gameFieldWindow.Show();
            mainWindow.Close();
        }

        private bool CanExecuteStartCommand(object param)
        {
            return true;
        }

        private void ExitGame(object param)
        {
            mainWindow.Close();
        }

        private bool CanExecuteExitCommand(object param)
        {
            return true;
        }
    }
}
