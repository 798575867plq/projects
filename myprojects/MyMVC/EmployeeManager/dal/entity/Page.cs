using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.dal.entity
{
    //用于计算分页的类
    public class Page
    {
        private int count = 0; //记录总数
        private int pageSize = 5; //分页大小
        private int pageNumber = 0; //当前页码
        private int pageCount = 0; //分页总数
        private int skip = 0;//分页查询要跳过的记录

        //只读属性
        public int PageCount
        {
            get
            {
                Compute(); //计算数值
                return pageCount;
            }
        }

        public int Skip
        {
            get
            {
                Compute();
                return skip;
            }
        }

        //读写属性
        public int Count
        {
            get { return count;}
            set { count = value; }
        }

        public int PageSize
        {
            get
            {
                Compute();
                return pageSize;
            }
            set { pageSize = value; }
        }

        public int PageNumber
        {
            get
            {
                Compute();
                return pageNumber;
            }
            set { pageNumber = value; }
        }

        //计算分页信息
        public void Compute()
        {
            if (count <= 0) //没有记录的情况
            {
                pageCount = 0;
                skip = 0;
                return;
            }
            //检查分页大小
            if (pageSize < 1)
            {
                pageSize = 5;
            }
            //计算分页总数
            pageCount = count / pageSize; //整除
            //如果除不尽，那么页码要加一
            if (count % pageSize > 1)
            {
                pageCount++;
            }
            //限制分页页码
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageNumber > pageCount)
            {
                pageNumber = pageCount;
            }
            //计算跳过的记录数
            skip = pageSize * (pageNumber - 1);

        }
    }
}