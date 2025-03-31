using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_2
{
    public class StarDecorator : DateDecorator
    {
        public StarDecorator(IDatePrinter printer) : base(printer)
        {
        }

        public override void Print()
        {
            Console.Write("*** ");
            printer.Print();
            Console.Write(" ***");
        }
    }
}
