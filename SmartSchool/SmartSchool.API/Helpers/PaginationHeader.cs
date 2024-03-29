using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPage { get; set; }
        public PaginationHeader(int currentPage, int totalItems, int itemsPerPage, int totalPage) 
        {
            this.CurrentPage = currentPage;
            this.TotalItems = totalItems;
            this.TotalPage = totalPage;
            this.ItemsPerPage = itemsPerPage;
   
        }
    }
}