using EmployeeManager.dal.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.dal.dao
{
    public class PageDAO
    {
        public static int Count()
        {
            return (int)DBHelper.QueryObject(@"select count(*) from TblEmployee");
        }

        public static List<Dictionary<string, object>> QueryPageData(Page page)
        {
            if (page.PageNumber == 1)
            {
                return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee", page.PageSize));
            }
            return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee where eid not in
                    (select top {1} eid from TblEmployee)", page.PageSize, page.Skip));
        }
    }
}