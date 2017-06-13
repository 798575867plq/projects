using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FileUpLoad
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        //文件上传的保存目录名称
        public const string UploadDir = "/files";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //确保上传文件保存目录存在
            //Server.MapPath是获取web应用的虚拟目录的真实路径
            DirectoryInfo info = new DirectoryInfo(Server.MapPath(UploadDir));
            if (!info.Exists) //目录不存在
            {
                info.Create(); //创建目录
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = Context.Request.FilePath;
            if ("/".Equals(path))
            {
                Context.RewritePath("/Default/");
            }
        }
    }
}