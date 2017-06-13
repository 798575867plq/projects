using EmployeeManager.dal.dao;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    //添加新的学校管理系统项目
    //数据库表是班级表和学生表，学生表要关联班级
    //完成基础框架
    //完成班级表的信息查询和添加功能

    //完成学生信息的分页查询
    //完成Session级别变量的演示

    public class DeptController : Controller
    {
        public ActionResult Index()
        {
            DeptModel model = new DeptModel();
            model.DeptList = TblDeptDAO.QueryAll();
            return View(model);
        }

        public ActionResult Add(DeptModel model)
        {
            try
            {
                TblDeptDAO.Add(model.Dept);
                model.Message = "添加部门信息成功！";
            }
            catch (Exception ex)
            {
                //捕获异常，将错误原因传递到页面
                model.Message = ex.Message;
            }

            //添加后要将试图转到首页
            model.DeptList = TblDeptDAO.QueryAll();
            return View("Index",model);
        }

        public ActionResult Delete(DeptModel model)
        {
            try
            {
                TblDeptDAO.Delete(model.Dept);
                model.Message = "删除成功。";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult ToModify(DeptModel model)
        {
            model.Dept = TblDeptDAO.QueryByKey(model.Dept);
            return View(model);
        }

        public ActionResult Modify(DeptModel model)
        {
            try
            {
                TblDeptDAO.Modify(model.Dept);
                model.Message = "修改信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToModify", model);
        }
    }
}
