using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models.ViewModel
{
    public class MonthlyReport
    {
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int Amount { get; set; }
    }
}
