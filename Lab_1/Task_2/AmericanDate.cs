using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_2
{
    internal class AmericanDate : BaseDate
    {
        public AmericanDate() 
        {
            SetDate("en-US");
        }

        public override void Print()
        {
            Console.Write(Date.ToString());
        }
    }
}
