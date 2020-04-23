using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TimerApp.Model;
using TimerApp.ViewModel.Commands;

namespace TimerApp.ViewModel
{
    class TimerViewModel : INotifyPropertyChanged
    {
        private List<Timer> timers;

        private Timer selectedTimer;
        private DispatcherTimer runningDispatcherTimer;
        private bool timerStarted;
        private bool timerPaused;
        private bool timerFromList;
        private string newTimerName;

        public Timer SelectedTimer
        {
            get { return selectedTimer; }
            set 
            {
                selectedTimer = value;
                OnPropertyChanged("SelectedTimer");
            }
        }

        private Timer runningTimer;

        public Timer RunningTimer
        {
            get { return runningTimer; }
            set 
            { 
                runningTimer = value;
                OnPropertyChanged("RunningTimer");
            }
        }

        public TimerEditCommand TimerEditCommand { get; set; }
        public StartPauseCommand StartPauseCommand { get; set; }
        public ResetCommand ResetCommand { get; set; }
        public SaveCommand SaveCommand { get; set; }

        public TimerViewModel()
        {
            SelectedTimer = new Timer("New Timer", 3665);
            RunningTimer = SelectedTimer.Clone() as Timer;

            RunningTimer.Duration = 7200;

            Timers = new List<Timer>();

            /*Timers.Add(SelectedTimer);
            Timers.Add(RunningTimer);
            Timers.Add(new Timer("Timer Name", 3665));*/

            TimerEditCommand = new TimerEditCommand(this);
            StartPauseCommand = new StartPauseCommand(this);
            ResetCommand = new ResetCommand(this);
            SaveCommand = new SaveCommand(this);

            timerStarted = false;
            timerPaused = false;
            timerFromList = false;

            ReadTimers();
        }
        
        public List<Timer> Timers
        {
            get { return timers; }
            set
            {
                timers = value;
                OnPropertyChanged("Timers");
            }
        }

        public bool TimerStarted
        {
            get { return timerStarted; }
            set 
            { 
                timerStarted = value;
                OnPropertyChanged("StartPauseButtonString");
            }
        }
        public bool TimerPaused
        {
            get { return timerPaused; }
            set
            {
                timerPaused = value;
                OnPropertyChanged("StartPauseButtonString");
            }
        }
        public bool TimerFromList
        {
            get { return timerFromList; }
            set
            {
                timerFromList = value;
                OnPropertyChanged("TimerFromList");
            }
        }

        public string StartPauseButtonString
        {
            get
            {
                if(!timerStarted)
                {
                    return "Start";
                }
                else if (!timerPaused)
                {
                    return "Pause";
                }
                else
                {
                    return "Resume";
                }
            }
        }

        public string NewTimerName
        {
            get { return newTimerName; }
            set
            {
                newTimerName = value;
                OnPropertyChanged("NewTimerName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TimerEditButtonClick(int delta)
        {
            RunningTimer.Duration += delta;
        }

        public void StartPauseTimer()
        {
            if (!timerFromList) SelectedTimer = RunningTimer.Clone() as Timer;

            if (!TimerStarted)
            {
                runningDispatcherTimer = new DispatcherTimer();
                runningDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                runningDispatcherTimer.Tick += TimerTick;
                runningDispatcherTimer.Start();
                TimerStarted = true;
            }
            else if (!TimerPaused)
            {
                runningDispatcherTimer.Tick -= TimerTick;
                TimerPaused = true;
            }
            else
            {
                runningDispatcherTimer.Tick += TimerTick;
                TimerPaused = false;
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if(RunningTimer.Duration > 0)
            {
                RunningTimer.Duration--;
            }
            else
            {
                runningDispatcherTimer.Tick -= TimerTick;
                SystemSounds.Exclamation.Play();
            }
        }

        public void ResetTimer()
        {
            if (timerStarted && !timerPaused)
            {
                runningDispatcherTimer.Tick -= TimerTick;
            }

            RunningTimer = SelectedTimer.Clone() as Timer;

            timerStarted = false;
            timerPaused = false;
        }

        public void SaveTimer()
        {
            if (!TimerFromList)
            {
                RunningTimer.Name = NewTimerName;
                DatabaseHelper.Insert(RunningTimer);
            }
            ReadTimers();
        }

        public void ReadTimers()
        {
            Timers = DatabaseHelper.ReadDatabase();
        }
    }
}
