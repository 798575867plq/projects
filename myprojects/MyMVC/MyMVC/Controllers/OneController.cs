using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class OneController : Controller
    {
        //
        //    /One/Index==>/Views/One/Index.cshtml

        public ActionResult Index()
        {
            //简单的传递值到View
            ViewBag.Info = "我是控制器通过ViewBag传递的值";
            return View();
        }

        public ActionResult Other()
        {
            ViewBag.Info = "另一个页面数据。。。";
            OneModel m = new OneModel();
            m.Id = 1000;
            m.Name = "小红...";

            return View(m);        
        }

    }
}
