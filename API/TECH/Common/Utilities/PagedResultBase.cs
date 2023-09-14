﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Utilities
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int RowCount { get; set; }
        public int PageCount
        {
            get
            {
                var pageCount =(double)RowCount / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set
            {
                 PageCount = value;
            }
        }
        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }
        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}
