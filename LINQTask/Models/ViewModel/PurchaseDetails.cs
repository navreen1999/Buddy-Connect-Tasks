using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models.ViewModel
{
    public class PurchaseDetails
    {
        public string CustomerName { get; set; }
        public int PurchaseOrderID { get; set; }
        public int Price { get; set; }
        public string ProductName { get; set; }
    }
}
