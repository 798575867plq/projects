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
    public class MessageController : Controller
    {
        public ActionResult Info(MessageModel model)
        {
            //查询指定id的帖子
            model.Info = TblMessageDAO.QueryByKey(model.Info);
            //查询帖子对应的回贴
            model.RList = TblReturnDAO.QueryByMid(model.Info);
            return View(model);
        }

        public ActionResult List(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            model.PageInfo.Count = TblMessageDAO.QueryUserCount(user);
            model.MList = TblMessageDAO.QueryUserPage(model.PageInfo, user);
            return View(model);
        }

        public ActionResult Add(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                //不需要页面提交当前用户，直接在Session中获取登录用户信息，然后给数据库添加
                model.Info.Uid = user.Uid;
                TblMessageDAO.Add(model.Info);
                model.Message = "添加成功！";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.PageInfo.Count = TblMessageDAO.QueryUserCount(user);
            model.MList = TblMessageDAO.QueryUserPage(model.PageInfo, user);
            return View("List", model);
        }

        public ActionResult Delete(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                TblMessageDAO.Delete(model.Info);
                model.Message = "删除成功！";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.PageInfo.Count = TblMessageDAO.QueryUserCount(user);
            model.MList = TblMessageDAO.QueryUserPage(model.PageInfo, user);
            return View("List", model);
        }

        public ActionResult AddReturn(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                model.RInfo.Uid = user.Uid;
                TblReturnDAO.Add(model.RInfo);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return Redirect("/Message/Info?Info.Mid=" + model.RInfo.Mid);
        }
    }
}
