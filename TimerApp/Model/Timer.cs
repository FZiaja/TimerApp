using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.Model
{
    public class Timer : ICloneable, INotifyPropertyChanged
    {
        private int duration;
        private static int maxDuration = (9 * 3600) + (59 * 60) + 59;

        public Timer()
        {

        }

        public Timer(string name, int duration)
        {
            Name = name;
            this.duration = duration;
        }

        public Timer(string name, int hours, int minutes, int seconds)
        {
            Name = name;
            this.duration = (3600 * hours) + (60 * minutes) + seconds;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Duration
        {
            get { return duration; }
            set 
            {
                if (value < 0)
                {
                    duration = 0;
                }
                else if (value > maxDuration)
                {
                    duration = maxDuration;
                }
                else 
                {
                    duration = value;
                }
                
                OnPropertyChanged("Duration");
                OnPropertyChanged("HoursStr");
                OnPropertyChanged("MinutesStr");
                OnPropertyChanged("SecondsStr");
            }
        }

        [MaxLength(50)]
        public string Name { get; set; }

        [Ignore]
        public int Hours
        {
            get { return duration / 3600; }
        }
        [Ignore]
        public string HoursStr
        {
            get { return Hours.ToString(); }
        }
        [Ignore]
        public int Minutes
        {
            get { return (duration / 60) % 60; }
        }
        [Ignore]
        public string MinutesStr
        {
            get { return Minutes.ToString().PadLeft(2, '0'); }
        }
        [Ignore]
        public int Seconds
        {
            get { return duration % 60; }
        }
        [Ignore]
        public string SecondsStr
        {
            get { return Seconds.ToString().PadLeft(2, '0'); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Hours}:{Minutes.ToString().PadLeft(2, '0')}:{Seconds.ToString().PadLeft(2, '0')}";
        }
    }
}
