using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.dal.dao;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class DefaultController : Controller
    {
        //创建QQ空间数据库
        //里面包括用户信息表
        //创建说说表
        //创建说说的回复表
        //创建QQ空间项目
        //完成基本MVC框架
        //完成用户登录登出和注册页面
        //完成回复和回复显示
        //完成说说发表功能

        //Session表示放置浏览器级别的变量
        //添加的方式是Session.Add("变量名",变量值)
        //获取的方式是Session["变量名"]
        //删除的方法是Session.Remove("变量名");

        //服务器页面转向的两个方法
        //RedirectToAction("方法名","控制器名");
        //Redirect("地址栏的url");

        public ActionResult Index(DefaultModel model)
        {
            model.PageInfo.Count = TblMessageDAO.QueryCount();
            model.MList = TblMessageDAO.QueryPage(model.PageInfo);
            return View(model);
        }

    }
}
