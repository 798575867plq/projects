using EmployeeManager.dal.dao;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index(PageModel model)
        {
            //设置记录数
            model.PageInfo.Count = PageDAO.Count();
            //查询分页数据
            model.PageData = PageDAO.QueryPageData(model.PageInfo);
            return View(model);
        }

    }
}
