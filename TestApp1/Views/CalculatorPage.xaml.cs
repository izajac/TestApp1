using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        int currentState = 1;
        string currentOperator;
        double x, y;
        
        public CalculatorPage()
        {
            InitializeComponent();
        }

        void OnNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonTapped = button.Text;
            double n;

            if (this.resultLabel.Text == "0" || currentState < 0)
            {
                this.resultLabel.Text = "";

                if (currentState < 0) currentState *= -1;
            }

            this.resultLabel.Text += buttonTapped;
            
            if (double.TryParse(this.resultLabel.Text, out n))
            {
                this.resultLabel.Text = n.ToString("N0");
                if (currentState == 1)
                {
                    x = n;
                }
                else
                {
                    y = n;
                }
            }
        }

        void OnOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string buttonTapped = button.Text;
            currentOperator = buttonTapped;
        }

        void OnClear(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            currentState = 1;
            this.resultLabel.Text = "0";
        }

        void OnPercent(object sender, EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = x / 100;
                this.resultLabel.Text = result.ToString();
                x = result;
                currentState = -1;
            }
        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                var result = Services.CalculateResult.Calculate(x, y, currentOperator);

                this.resultLabel.Text = result.ToString();
                x = result;
                currentState = -1;
            }
        }

        void OnSquareRoot(object sender, EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = Math.Sqrt(x);

                this.resultLabel.Text = result.ToString();
                x = result;
                currentState = -1;
            }
        }

        void OnSquare(object sender, EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {
                var result = x * x;
                this.resultLabel.Text = result.ToString();
                x = result;
                currentState = -1;
            }
        }
    }
}