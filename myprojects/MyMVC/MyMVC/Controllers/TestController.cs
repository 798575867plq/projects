using MyMVC.dal.dao;
using MyMVC.dal.entity;
using MyMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    /*
     * 作业：创建学校管理系统数据库
     * 里面包括：班级表和学生表
     * 
     * 创建学校管理系统的MVC项目
     * 完成全部实体层
     * 完成数据库访问层的DBConn
     * 
     * 添加测试用MVC，测试数据库连接
     * 
     * 添加DBHelper数据库访问辅助类
     * 添加页面测试DBHelper的查询和修改方法是否正确
     */
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            TestModel model = new TestModel();
            //TblDept dept = new TblDept();
            //dept.DeptId = 100;
            //dept.DeptName = "测试部";
            //dept.DeptInfo = "测试信息。。。";

            TblDept dept = DBHelper.QueryOne(new TblDept(), "select top 1 * from TblDept");
            model.Dept = dept;

            model.DeptList = DBHelper.QueryList(new TblDept(), "select * from TblDept");
            
            using (SqlConnection conn = DBConn.GetConn())
            {
                model.DataBase = conn.Database;
                conn.Close();
            }

            model.Properties = DBHelper.GetPropertyInfos(new TblEmployee());

            ViewBag.Count = DBHelper.QueryObject("select count(*) from TblEmployee");
            ViewBag.UpdateCount = DBHelper.Update(@"insert into TblDept(deptName,deptInfo) values(@p0,@p1)","哈哈哈","嘻嘻");

            return View(model);
        }

    }
}
