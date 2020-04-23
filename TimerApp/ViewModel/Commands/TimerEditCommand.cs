using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimerApp.ViewModel.Commands
{
    class TimerEditCommand : ICommand
    {
        public TimerViewModel VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public TimerEditCommand(TimerViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return (!VM.TimerStarted);
        }

        public void Execute(object parameter)
        {
            int delta = int.Parse(parameter as string);

            VM.TimerEditButtonClick(delta);
        }
    }
}
