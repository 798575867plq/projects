using System;
using EmployeeManager.dal.entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class EmployeeModel
    {
        public List<VwEmpDept> VwList { get; set; }

        public string Message { get; set; }
        public TblEmployee Employee { get; set; }
        public List<TblEmployee> EmployeeList { get; set; }
        public List<TblDept> DeptList { get; set; }

        public List<Dictionary<string, object>> DicList { get; set; }
        public List<Dictionary<string, object>> PageList { get; set; }

        //当前分页页码
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}