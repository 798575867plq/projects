using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.dal.dao;
using WeiBo.dal.entity;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult ToReg()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult Reg(UserModel model)
        {
            try
            {
                TblUserDAO.Reg(model.User);
                model.Message = "注册成功！";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToReg", model);
        }

        public ActionResult Login(UserModel model)
        {
            try
            {
                TblUser user = TblUserDAO.Login(model.User);
                if (user != null) //登录成功的情况
                {
                    //将登录用户信息放到浏览器级别（Session）的变量中
                    Session.Add("LoginUser", user);
                    //通知浏览器终止当前页面访问跳转到其他页面
                    //第一个参数是方法名，第二个参数是控制器名
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    model.Message = "登录失败！";
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index", model);
        }

        public ActionResult Logout()
        {
            //移除Session中的登录用户信息
            Session.Remove("LoginUser");
            return RedirectToAction("Index", "User");
        }
    }
}
