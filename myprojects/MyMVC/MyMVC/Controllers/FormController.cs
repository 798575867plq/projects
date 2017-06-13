using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class FormController : Controller
    {
        private static List<TblType> GetTypes()
        {
            List<TblType> list = new List<TblType>();
            TblType type = new TblType();
            type.Tid = 1000;
            type.Tname = "用户";
            list.Add(type);

            type = new TblType();
            type.Tid = 2000;
            type.Tname = "管理员";
            list.Add(type);

            return list;
        }

        public ActionResult Index()
        {
            FormModel m = new FormModel();
            m.Types = FormController.GetTypes();
            return View(m);
        }

        public ActionResult Login(FormModel m)
        {
            m.Types = FormController.GetTypes();

            if(String.IsNullOrWhiteSpace(m.Name))
            {
                m.Error = "用户名必须填写";
                //return View("当前控制器的其它视图",Model对象)
                //是将请求转到当前控制器的指定视图并传递Model数据
                return View("Index", m);
            }

            if (String.IsNullOrWhiteSpace(m.Password))
            {
                m.Error = "密码必须填写";    
                return View("Index", m);
            }
            return View(m);
        }
    }
}
