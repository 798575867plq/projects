using EmployeeManager.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class DeptModel
    {
        //服务器消息
        public string Message { get; set; }
        //查询列表
        public List<TblDept> DeptList { get; set; }
        //表单提交信息
        public TblDept Dept { get; set; }
    }
}