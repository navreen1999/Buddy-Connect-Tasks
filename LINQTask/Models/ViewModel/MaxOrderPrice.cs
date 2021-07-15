using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models.ViewModel
{
    public class MaxOrderPrice
    {
        public DateTime Date { get; set; }
        public int PurchaseOrderID { get; set; }
        public int Price { get; set; }
    }
}
