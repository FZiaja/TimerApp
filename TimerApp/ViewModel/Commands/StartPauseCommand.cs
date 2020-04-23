using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimerApp.ViewModel.Commands
{
    class StartPauseCommand : ICommand
    {
        public TimerViewModel VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public StartPauseCommand(TimerViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return VM.RunningTimer.Duration != 0;
        }

        public void Execute(object parameter)
        {
            VM.StartPauseTimer();
        }
    }
}
