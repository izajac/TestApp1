using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp1.Services
{
    public static class CalculateResult
    {
        public static double Calculate(double x, double y, string currentoperator)
        {
            double result = 0;
            switch(currentoperator)
            {
                case "+":
                    result = x + y;
                    break;
                case "-":
                    result = x - y;
                    break;
                case "÷":
                    result = x / y;
                    break;
                case "×":
                    result = x * y;
                    break;
            }
            return result;
        }
    }
}
