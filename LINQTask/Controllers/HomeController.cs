using LINQTask.Models;
using LINQTask.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LINQTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private purchaseContext _context;

        public HomeController(purchaseContext context)
        {
            _context = context;
        }
     

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult ListOfPurchaseDetails()
        {
            List<PurchaseDetails> purchaseDetails = new List<PurchaseDetails>();
            purchaseDetails = (from c in _context.Customers
                               join po in _context.PurchaseOrders on
                               c.CustomerID equals po.CustomerID
                               join pod in _context.PurchaseOrderDetails on
                               po.PurchaseOrderId equals pod.PurchaseOrderID
                               join p in _context.Products on
                                pod.ProductID equals p.ProductID
                               orderby c.CustomerID
                               select new PurchaseDetails
                               {
                                   CustomerName = c.CustomerName,
                                   PurchaseOrderID = po.PurchaseOrderId,
                                   Price = pod.Price,
                                   ProductName = p.ProductName
                               }).ToList() ;
            return View(purchaseDetails);
        }
        public IActionResult MonthlyReport()
        {
            List<Customer> customer = _context.Customers.ToList();
            List<Product> product = _context.Products.ToList();
            List<PurchaseOrder> purchaseOrder = _context.PurchaseOrders.ToList();
            List<PODetail> purchaseOrderDetail = _context.PurchaseOrderDetails.ToList();
            List<MonthlyReport> monthlyReports = new List<MonthlyReport>();
            
            
            monthlyReports = (from c in customer
                              join po in purchaseOrder
                              on c.CustomerID equals po.CustomerID
                              orderby po.Date.Month
                              select new MonthlyReport
                              {
                                 Date= po.Date,
                                  CustomerName = c.CustomerName,
                                  Amount = po.Amount
                              }).ToList();
            return View(monthlyReports);
        }
        public IActionResult ProductSales()
        {
            List<ProductInfo> productInfo = new List<ProductInfo>();
            var pInfo = (from p in _context.Products
                         join pod in _context.PurchaseOrderDetails on
                         p.ProductID equals pod.ProductID
                         join po in _context.PurchaseOrders
                         on pod.PurchaseOrderID equals po.PurchaseOrderId

                         orderby p.ProductName ascending

                         select new ProductInfo
                         {
                            
                            Date=po.Date,
                             ProductName = p.ProductName,
                             Quantity = pod.Quantity
                         }).ToList().OrderBy(s => s.ProductName).ToList();
            return View(pInfo);
        }
       public IActionResult MaxOrderPrice()
        {
            
            var orderPrices = (from po in _context.PurchaseOrderDetails
                               join pod in _context.PurchaseOrders
                               on po.PurchaseOrderID equals pod.PurchaseOrderId
                               orderby pod.Date.Month
                               
                               select new MaxOrderPrice
                               {
                                   Date =pod.Date,

                                   PurchaseOrderID =po.PurchaseOrderID,
                                   Price = pod.Price
                               });

            return View(orderPrices);
        }
    }
}
