namespace EatThatChicken.ViewModel
{
    using EatThatChicken.Common;
    using System.Windows.Input;
    using EatThatChicken.View;

    class MainViewModel
    {
        private MainWindow mainWindow;

        //field startCommand,exitCommand-btnStart,btnExit
        private CommandBase startCommand;
        private CommandBase exitCommand;
        private CommandBase openInstructions;
        private CommandBase highScoreCommand;
        //constructor 
        public MainViewModel(MainWindow window)
        {
            mainWindow = window;
        }

        //property btnStart,btnExit,openInstructions
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
        public ICommand OpenInstructions
        {
            get
            {
                if (this.openInstructions == null)
                {
                    this.openInstructions = new CommandBase(this.OpenInstructionsMethod, this.CanExecuteOpenInstructions);
                }
                return this.openInstructions;
            }
        }
        public ICommand HighScoreCommand
        {
            get
            {
                if (this.highScoreCommand == null)
                {
                    this.highScoreCommand = new CommandBase(this.OpenHighScore, this.CanExecuteOpenHighScore);
                }
                return this.highScoreCommand;
            }
        }
        //methods for opening/closing windows btnStart,btnExit,openInstructions
        private void StartGame(object param)
        {
            GameFieldWindow gameFieldWindow = new GameFieldWindow();
            gameFieldWindow.Show();
            mainWindow.Close();
        }
        private void OpenInstructionsMethod(object param)
        {
            Instructions instructions = new Instructions();
            instructions.Show();
            mainWindow.Close();
        }
        private void ExitGame(object param)
        {
            mainWindow.Close();
        }

        private void OpenHighScore(object obj)
        {
            HighScoreWindow highScore = new HighScoreWindow();
            highScore.Show();
            mainWindow.Close();
        }

        private bool CanExecuteStartCommand(object param)
        {
            return true;
        }

        private bool CanExecuteExitCommand(object param)
        {
            return true;
        }

        private bool CanExecuteOpenInstructions(object obj)
        {
            return true;
        }

        private bool CanExecuteOpenHighScore(object obj)
        {
            return true;
        }
    }
}
