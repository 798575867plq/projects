using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.Models
{
    public class UserModel
    {
        public string Message { get; set; }
        public TblUser User { get; set; }
    }
}