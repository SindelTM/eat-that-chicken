namespace EatThatChicken.ViewModel
{
    using Common;
    using Common.Constants;
    using Models;
    using Models.Exceptions;
    using Models.Serialization;
    using System;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Input;
    using View;

    class EndGameViewModel
    {
        private readonly EndGameWindow window;

        private readonly int points;

        public EndGameViewModel(EndGameWindow window, int points)
        {
            this.TryAgainCommand = new CommandBase(ExecuteTryAgain, CanExecuteTryAgain);
            this.EnterCommand = new CommandBase(ExecuteEnter, CanExecuteEnter);
            this.window = window;
            this.points = points;
        }

        public ICommand TryAgainCommand { get; }

        public ICommand EnterCommand { get; }

        private void ExecuteTryAgain(object obj)
        {
            GameFieldWindow win = new GameFieldWindow();
            this.window.Close();
            win.Show();
        }

        private bool CanExecuteTryAgain(object obj)
        {
            return true;
        }

        private void ExecuteEnter(object obj)
        {
            string name = this.window.nameTextBox.Text;
            if (!string.IsNullOrEmpty(name))
            {
                SaveScore(name, this.points);
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.window.Close();
        }

        private bool CanExecuteEnter(object obj)
        {
            return true;
        }

        private void SaveScore(string name, int points)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string fileName = GlobalConstants.ScorFilePath;
            RecordSerializer serilizer = new RecordSerializer(formatter, fileName);

            HighScoreContainer container = GetContainer(serilizer);

            Player player = new Player(DateTime.Now, name, points);

            container.Add(player);

            SaveContainer(container, serilizer);
        }

        private HighScoreContainer GetContainer(RecordSerializer serilizer)
        {
            try
            {
                return serilizer.Deserialize();
            }
            catch (RecordSerializationException)
            {
                //Log Error
                return new HighScoreContainer();
            }
        }

        private void SaveContainer(HighScoreContainer container, RecordSerializer serilizer)
        {
            try
            {
                serilizer.Serialize(container);
            }
            catch (RecordSerializationException)
            {
                //Log Error
                return;
            }
        }
    }
}
