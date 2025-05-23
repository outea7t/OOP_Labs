using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_2
{
    public abstract class DateDecorator : IDatePrinter
    {
        protected IDatePrinter printer;

        protected DateDecorator(IDatePrinter printer)
        {
            this.printer = printer;
        }

        public abstract void Print();
    }
}
