using EatThatChicken.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EatThatChicken.View;

namespace EatThatChicken.ViewModel
{
    class MainViewModel
    {
        private MainWindow firstWindow;
        //field startCommand,exitCommand-btnStart,btnExit
        private ICommand startCommand;
        private ICommand exitCommand;

        //property btnStart,btnExit
        public ICommand StartCommand
        {
            get
            {
                if (startCommand == null)
                {
                    startCommand = new CommandBase(i => this.StartGame(), null);
                }
                return startCommand;
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new CommandBase(i => this.ExitGame(), null);
                }
                return exitCommand;
            }
        }

        //methods for opening/closing windows btnStart,btnExit
        private void StartGame()
        {
            secondWindow secondWindow = new secondWindow();
            secondWindow.Show();
            firstWindow.Close();
        }
        private void ExitGame()
        {
            firstWindow.Close();
        }
       
        //constructor 
        public MainViewModel(MainWindow window)
        {
            firstWindow = window;
        }
    }
}
