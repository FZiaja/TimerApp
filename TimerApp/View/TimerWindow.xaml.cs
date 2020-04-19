using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TimerApp.Model;

namespace TimerApp.View
{
    /// <summary>
    /// Interaction logic for TimerWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        public TimerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer("Test Timer", 3665);
            /*string dbName = "Timers.db";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbPath = System.IO.Path.Combine(path, dbName);

            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<Timer>();
                conn.Insert(timer);
            }*/
        }
    }
}
