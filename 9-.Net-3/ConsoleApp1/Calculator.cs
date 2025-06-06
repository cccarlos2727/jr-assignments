using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculator
    {
        #region Overload method
        public static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        public static void Add(double dou1, double dou2)
        {
            Console.WriteLine(dou1 + dou2);
        }
        #endregion

    }
}
