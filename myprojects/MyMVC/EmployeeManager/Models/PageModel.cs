using EmployeeManager.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class PageModel
    {
        public Page PageInfo { get; set; }
        public string Message { get; set; }
        public List<Dictionary<string, object>> PageData { get; set; }

        //创建模型就要给出默认值
        public PageModel()
        {
            //全部对象给出默认值
            //防范页面初始进入没有值
            Message = "";
            PageInfo = new Page();
            PageData = new List<Dictionary<string, object>>();
        }
    }
}