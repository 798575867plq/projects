using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class SessionController : Controller
    {
        public ActionResult Index(string uname)
        {
            //记录浏览器级别变量
            if (!string.IsNullOrWhiteSpace(uname))
            {
                Session.Add("LoginUser", uname);
            }
            return View();
        }

        public ActionResult One()
        {
            return View();
        }

    }
}
