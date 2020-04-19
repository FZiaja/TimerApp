using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimerApp.Model;

namespace TimerApp.View.Controls
{
    /// <summary>
    /// Interaction logic for TimerControl.xaml
    /// </summary>
    public partial class TimerControl : UserControl
    {
        public Timer Timer
        {
            get { return (Timer)GetValue(TimerProperty); }
            set { SetValue(TimerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Timer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimerProperty =
            DependencyProperty.Register("Timer", typeof(Timer), typeof(TimerControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
            TimerControl control = d as TimerControl;

            if(control != null)
            {
                //control.nameTextBlock.Text = (e.NewValue as Timer).Name
            }
        }

        public TimerControl()
        {
            InitializeComponent();
        }
    }
}
