using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerApp.Model
{
    public class Timer
    {
        private int duration;

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
            set { duration = value; }
        }

        [MaxLength(50)]
        public string Name { get; set; }

        [Ignore]
        public int Hours
        {
            get { return duration / 3600; }
        }
        [Ignore]
        public int Minutes
        {
            get { return (duration / 60) % 60; }
        }
        [Ignore]
        public int Seconds
        {
            get { return duration % 60; }
        }

        public override string ToString()
        {
            // TODO: Pad with zeros.
            return "";
        }
    }
}
