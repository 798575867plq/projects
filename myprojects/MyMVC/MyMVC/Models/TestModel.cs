using MyMVC.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyMVC.Models
{
    public class TestModel
    {
        public TblDept Dept { get; set; }
        public List<TblDept> DeptList { get; set; }
        public String DataBase { get; set; }
        public Dictionary<string, PropertyInfo> Properties { get; set; }
    }
}