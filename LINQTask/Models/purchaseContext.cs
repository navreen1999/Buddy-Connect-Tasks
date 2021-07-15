using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Models
{
    public class purchaseContext:DbContext
    {
        public purchaseContext()
        {

        }
        public purchaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PODetail> PurchaseOrderDetails { get; set; }
    }
}
