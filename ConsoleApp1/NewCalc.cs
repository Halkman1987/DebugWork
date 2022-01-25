using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWork1
{
    public class CalculateP : ICalc<double,double>
    {
        ILogger Logger { get;  }
        public CalculateP(ILogger logger)
        {
             Logger = logger;
        }

        public double Calc(double x, double y)
        {
            Logger.Event("  Начинается подсчет суммы чисел .");
            Thread.Sleep(2000);
            return x + y;
           
        }
    }
    public class CalculateM : ICalc<double, double>
    {
        ILogger Logger { get; }
        public CalculateM(ILogger logger)
        {
            Logger = logger;
        }

        public double Calc(double x, double y)
        {
            Logger.Event("  Начинается подсчет суммы чисел .");
            Thread.Sleep(2000);
            return x - y;

        }
    }
}
