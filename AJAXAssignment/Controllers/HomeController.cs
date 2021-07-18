using AJAXAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AJAXAssignment.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckEmail(Employee employee)
        {
            
            List<string> email = new List<string>();
            email.Add("navreen019@gmail.com");
            email.Add("nav_shifa019@gmail.com");
            email.Add("nav_faz@gmail.com");
            var IsEmailAvailable = (from s in email select s).Contains(employee.Email);
            if (IsEmailAvailable == true)
            {
                return Json(new { msg = "success", data = employee });
            }
            return Json(new { msg = "failed" });
        }
    }
}
