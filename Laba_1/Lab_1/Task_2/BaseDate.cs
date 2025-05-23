using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Task_2
{
    
    public abstract class BaseDate : IDatePrinter
    {
        protected StringBuilder Date = new StringBuilder();
        protected void SetDate(string cultureCode)
        { 
            CultureInfo info = new CultureInfo(cultureCode, false);
            Date = new StringBuilder(DateTime.Now.ToString(info));
        }
        ~BaseDate() 
        {
            Date.Clear();
        }
        public abstract void Print();
    }
}
