using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDLUsingAJAX.Models;

namespace DDLUsingAJAX.Controllers
{
    public class HomeController : Controller
    {
        public dbCountryEntities entity = new dbCountryEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Country = entity.Countries.ToList();
           
            return View();
        }
       [HttpGet]
        public JsonResult GetStates(int Country_id)
        {
            var states = entity.States.Where(s => s.Country_id == Country_id).Select
                (s => new
                {
                    Id = s.State_id,
                    StateName = s.State_name
                }).ToList();


            return Json(new { msg = "success", data = states },JsonRequestBehavior.AllowGet);
                        

        }
        [HttpGet]
        public JsonResult GetCity(int State_id)
        {
            var city = entity.Cities.Where(s => s.State_id == State_id).Select(
                s => new
                {
                    City_id = s.City_id,
                    City_Name = s.City_name
                }
                );
            return Json(new { msg = "success", data = city }, JsonRequestBehavior.AllowGet);
        }
    }
}