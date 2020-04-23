using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using TimerApp.Model;

namespace TimerApp.ViewModel
{
    class DatabaseHelper
    {
        public static string dbName = "Timers.db";
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string dbPath = System.IO.Path.Combine(path, dbName);

        public static void Insert(Timer timer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Timer>();
                conn.Insert(timer);
            }
        }

        public static List<Timer> ReadDatabase()
        {
            List<Timer> timers;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Timer>();
                timers = conn.Table<Timer>().ToList();
            }

            //ListView placeholderLV = new ListView();

            /*if(timers != null)
            {
                placeholderLV.ItemsSource = timers;
            }*/
            return timers;
        }

        public static void Delete(Timer timer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                // Make sure the timer has an Id before deleting.
                conn.CreateTable<Timer>();
                conn.Delete(timer);
            }
        }

        public static void Update(Timer timer)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Timer>();
                conn.Update(timer);
            }
        }
    }
}
