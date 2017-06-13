using EmployeeManager.dal.dao;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeModel model = new EmployeeModel();
            model.DeptList = TblDeptDAO.QueryAll();
            model.EmployeeList = TblEmployeeDAO.QueryAll();
            return View(model);
        }

        public ActionResult Add(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Add(model.Employee);
                model.Message = "添加信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            model.EmployeeList = TblEmployeeDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult ToModify(EmployeeModel model)
        {
            try
            {
                model.Employee = TblEmployeeDAO.QueryByKey(model.Employee);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View(model);
        }

        public ActionResult Modify(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Modify(model.Employee);
                model.Message = "修改成功。。。";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View("ToModify", model);
        }

        public ActionResult Delete(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Delete(model.Employee);
                model.Message = "删除信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            model.EmployeeList = TblEmployeeDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult List()
        {
            EmployeeModel model = new EmployeeModel();
            SetListData(model);
            return View(model);
        }

        public ActionResult Page(EmployeeModel model)
        {
            SetListData(model);
            return View("List", model);
        }

        private void SetListData(EmployeeModel model)
        {
            //页码初始值处理(下限控制)
            if (model.Page <= 0)
            {
                model.Page = 1;
            }
            if (model.PageSize <= 0)
            {
                model.PageSize = 5;
            }
            model.VwList = TblEmployeeDAO.QueryVw();

            //数据查询
            model.DicList = TblEmployeeDAO.QueryAllDept();
            //分页查询
            model.PageList = TblEmployeeDAO.QueryPage(model.Page, model.PageSize);
        }


    }
}
