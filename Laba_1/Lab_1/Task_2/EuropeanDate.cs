using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_2
{
    public class EuropeanDate : BaseDate
    {
        public EuropeanDate() 
        {
            SetDate("fr-FR");    
        }

        public override void Print()
        {
            Console.Write(Date.ToString());
        }
    }
}
