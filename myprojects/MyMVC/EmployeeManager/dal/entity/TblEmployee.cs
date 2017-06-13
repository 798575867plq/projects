using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.dal.entity
{
    public class TblEmployee
    {
        public int Eid { get; set; }
        public int DeptId { get; set; }
        public string Ename { get; set; }
        public string Sex { get; set; }
        public decimal Salary { get; set; }
        public DateTime Indate { get; set; }
    }
}