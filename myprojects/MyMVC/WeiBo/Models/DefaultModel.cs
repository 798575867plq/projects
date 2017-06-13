using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.Models
{
    public class DefaultModel
    {
        public Page PageInfo { get; set; }
        public List<TblMessage> MList { get; set; }
        public string Message { get; set; }

        public DefaultModel()
        {
            PageInfo = new Page();
            MList = new List<TblMessage>();
            Message = "";
        }
    }
}