using EatThatChicken.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EatThatChicken.View;
using EatThatChicken.ViewModel.Commands;
using EatThatChicken.Engines;

namespace EatThatChicken.ViewModel
{
    class MainViewModel
    {
        private MainWindow firstWindow;

        //field startCommand,exitCommand-btnStart,btnExit
        private RelayCommand startCommand;
        private RelayCommand exitCommand;

        //constructor 
        public MainViewModel(MainWindow window)
        {
            firstWindow = window;
        }

        //property btnStart,btnExit
        public ICommand StartCommand
        {
            get
            {
                if (this.startCommand == null)
                {
                    this.startCommand = new RelayCommand(this.StartGame);
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
                    this.exitCommand = new RelayCommand(this.ExitGame);
                }
                return this.exitCommand;
            }
        }

        //methods for opening/closing windows btnStart,btnExit
        private void StartGame()
        {
            GameFieldWindow secondWindow = new GameFieldWindow();
            secondWindow.Show();
            firstWindow.Close();
        }

        private void ExitGame()
        {
            firstWindow.Close();
        }
    }
}
