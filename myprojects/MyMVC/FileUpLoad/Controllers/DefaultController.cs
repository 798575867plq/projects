using FileUpLoad.dal.dao;
using FileUpLoad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpLoad.Controllers
{
    public class DefaultController : Controller
    {
        //创建用户上传文件管理数据库
        //  包含用户表和用户文件表
        //创建用户上传文件管理项目
        //  完成基本框架和实体层
        //  完成上传目录的检查和自动创建
        public ActionResult Index(DefaultModel model)
        {
            model.PageInfo.Count = TblFilesDAO.QueryCount();
            model.Files = TblFilesDAO.QueryPage(model.PageInfo);
            return View(model);
        }

        //HttpPostedFileBase对应type=file的表单元素名称
        public ActionResult Add(DefaultModel model,HttpPostedFileBase uploadfile)
        {
            //通过Guid生成不重复的文件名，用于把上传的文件保存到服务器中
            string filepath = Guid.NewGuid().ToString();
            string savepath = Server.MapPath(FileUpLoad.MvcApplication.UploadDir + "/" + filepath);
            //把上传文件保存到指定位置
            uploadfile.SaveAs(savepath);
            //记录到数据库的名称
            model.UpFile.Filepath = filepath;
            //获取上传文件的原始名称
            string filename = uploadfile.FileName;
            //处理ie浏览器上传的是完整名称的问题
            if (filename.IndexOf("\\") > -1)
            {
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            model.UpFile.Filename = filename;
            //获取上传文件的大小
            model.UpFile.Size = uploadfile.ContentLength;
            //获取上传文件的mime类型
            model.UpFile.ContentType = uploadfile.ContentType;
            TblFilesDAO.Add(model.UpFile);
            return RedirectToAction("Index", "Default");
        }

    }
}
