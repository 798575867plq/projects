using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //拦截请求，当客户端请求页面的时候会首先进入该方法

        public void Application_BeginRequest(object sender,EventArgs e)
        {
            //获取请求的文件路径
            string path = Context.Request.FilePath;
            //如果是跟目录且没有指定文件名称
            if("/".Equals(path))
            {
                //强制改写用户请求的文件路径
                Context.RewritePath("/index.html");
                //文件路径可以是mvc的
                //Context.RewritePath("/One/Index");
            }
        }

        //拦截错误
        public void Application_Error(object sender,EventArgs e)
        {
            //获取最后的错误信息
            Exception ex = Server.GetLastError();
            //判断是否为http错误
            if(!(ex is HttpException))
            {
                return;            
            }
            //取回http的错误编码
            int code = ((HttpException)ex).GetHttpCode();
            if (code == 404)
            {
                //强制让浏览器转到自定义错误页
                Response.Redirect("/Error/Error404");
            }
        }

    }
}