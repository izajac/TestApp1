using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp1.ViewModels
{
    //public class StopwatchModel : BaseViewModel
    //{
    //    public Stopwatch StopwatchX = new Stopwatch();
    //
    //    public Command StartCommand { get; set; }
    //
    //    private string stopwatchLabelValue = string.Empty;
    //    
    //    public string StopwatchLabel 
    //    { 
    //        get
    //        {
    //            return this.stopwatchLabelValue;
    //        }
    //        set
    //        {
    //            if (value != this.stopwatchLabelValue)
    //            {
    //                this.stopwatchLabelValue = value;
    //            }
    //        }
    //    }
    //    
    //    public StopwatchModel()
    //    {
    //        Title = "Stopwatch";
    //
    //        StopwatchX = new Stopwatch();
    //
    //        StopwatchLabel = StopwatchX.Elapsed.ToString();
    //        
    //        StartCommand = new Command(OnStart);
    //    }
    //
    //    public void OnStart()
    //    {
    //        StopwatchX.Start();
    //
    //        Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
    //        {
    //            StopwatchLabel = StopwatchX.Elapsed.ToString();
    //
    //            return true;
    //        }
    //
    //        );
    //    }
    //
    //}
}