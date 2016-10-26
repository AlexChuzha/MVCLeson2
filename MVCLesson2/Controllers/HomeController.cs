using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExceptionLoggerApp.Models;
using ExceptionLoggerApp.Filters;

namespace MVCLesson2.Controllers
{
    public class HomeController : Controller
    {

        LoggerContext db = new LoggerContext();

        public ActionResult Index()
        {
            return View(db.ExceptionDetails.ToList());
        }

        [ExceptionLogger]
        public ActionResult Test(int id)
        {
            if (id > 3)
            {
                int[] mas = new int[2];
                mas[6] = 4;
            }
            else if (id < 3)
            {
                throw new Exception("id не может быть меньше 3");
            }
            else
            {
                throw new Exception("Некорректное значение для параметра id");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult CheckName(string name)
        {
            var result = !(name == "Название");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}