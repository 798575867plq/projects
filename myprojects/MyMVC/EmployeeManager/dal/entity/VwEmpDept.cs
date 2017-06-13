using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.dal.entity
{
    //联合查询的实体类，继承主查询表
    public class VwEmpDept:TblEmployee
    {
        //附加join表的字段
        public string DeptName { get; set; }
        public string DeptInfo { get; set; }
    }
}