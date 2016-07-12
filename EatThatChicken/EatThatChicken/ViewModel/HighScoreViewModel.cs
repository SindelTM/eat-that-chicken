namespace EatThatChicken.ViewModel
{
    using Common;
    using Common.Constants;
    using Models;
    using Models.Exceptions;
    using Models.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Input;
    using View;
    public class HighScoreViewModel
    {
        private readonly HighScoreContainer container;
        private HighScoreWindow window;

        public HighScoreViewModel(HighScoreWindow window)
        {
            this.window = window;
            this.container = getContainer();
            this.window.Scores.ItemsSource = container.GetRecords();
            this.BackCommand = new CommandBase(this.ExecuteBackCommand, this.CanExecuteBackCommand);
        }

        public ICommand BackCommand { get; }

        private HighScoreContainer getContainer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string fileName = GlobalConstants.ScorFilePath;
            RecordSerializer serilizer = new RecordSerializer(formatter, fileName);

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

        private void ExecuteBackCommand(object obj)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.window.Close();
        }

        private bool CanExecuteBackCommand(object obj)
        {
            return true;
        }
    }
}
