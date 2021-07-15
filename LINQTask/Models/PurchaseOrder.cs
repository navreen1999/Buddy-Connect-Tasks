using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models
{
    public class PurchaseOrder
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int Amount { get; set; }
    }
}
