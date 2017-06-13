using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVC.Models
{
    public class FormModel
    {
        //作业：完成用户注册功能演示
        //  表单：用户名，密码，确认密码
        //  校验：用户名，密码必须填写，确认密码和密码必须一致
        //成功：显示注册的用户名
        //失败：返回注册页面并提示错误


        //表单提交的部分
        public string Name { get; set; }
        public string Password { get; set; }

        //错误信息
        public string Error { get; set; }

        //二级的复杂数据
        public List<TblType> Types { get; set; }
    }
}