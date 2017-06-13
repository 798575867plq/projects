using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.dal.entity;

namespace WeiBo.Models
{
    public class MessageModel
    {
        public string Message { get; set; }
        public TblMessage Info { get; set; }
        public List<TblReturn> RList { get; set; }
        public List<TblMessage> MList { get; set; }
        public Page PageInfo { get; set; }
        public TblReturn RInfo { get; set; }

        public MessageModel()
        {
            Message = "";
            Info = new TblMessage();
            RList = new List<TblReturn>();
            MList = new List<TblMessage>();
            PageInfo = new Page();
            RInfo = new TblReturn();
        }
    }
}