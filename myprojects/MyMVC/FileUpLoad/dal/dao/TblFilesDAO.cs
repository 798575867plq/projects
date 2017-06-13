using FileUpLoad.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpLoad.dal.dao
{
    public class TblFilesDAO
    {
        public static int QueryCount()
        {
            return (int)DBHelper.QueryObject(@"select count(*) from TblFiles");
        }

        public static List<TblFiles> QueryPage(Page page)
        {
            return DBHelper.QueryList(new TblFiles(),string.Format
                (@"select top {0} * from TblFiles where fid not in (select top {1} fid from TblFiles)"
                ,page.PageSize,page.Skip));
        }

        public static int Add(TblFiles files)
        {
            return DBHelper.Update(@"insert into TblFiles(filepath,filename,size,description,contentType)
                values(@p0,@p1,@p2,@p3,@p4)"
                , files.Filepath, files.Filename, files.Size, files.Description, files.ContentType);
        }
    }
}