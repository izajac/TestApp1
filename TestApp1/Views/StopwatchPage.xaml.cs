using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopwatchPage : ContentPage
    {
        Stopwatch stopwatchX;
        
        public StopwatchPage()
        {
            InitializeComponent();

            stopwatchX = new Stopwatch();
        }

        private void OnStart(object sender, EventArgs e)
        {
            stopwatchX.Start();

            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                stopwatchLabel.Text = stopwatchX.Elapsed.ToString();
                return true;
            }
            );
        }

        private void OnStop(object sender, EventArgs e)
        {
            stopwatchX.Stop();
        }

        private void OnReset(object sender, EventArgs e)
        {
            stopwatchX.Reset();
        }
    }
}