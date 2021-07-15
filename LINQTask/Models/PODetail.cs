using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models
{
    public class PODetail
    {
        [Key]
        public  int PurchaseDetailsID { get; set; }

        [ForeignKey("PurchaseOrder")]
        public int PurchaseOrderID  { get; set; }

        [ForeignKey("Product")]
        public int ProductID    { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }
    }
}
