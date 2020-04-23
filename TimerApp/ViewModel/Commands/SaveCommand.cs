using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimerApp.ViewModel.Commands
{
    class SaveCommand: ICommand
    {
        public TimerViewModel VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SaveCommand(TimerViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            if (VM.TimerStarted) return false;
            return (!string.IsNullOrEmpty(VM.NewTimerName));
        }

        public void Execute(object parameter)
        {
            VM.SaveTimer();
        }
    }
}
