using BusLay.Interfaces;
using DAL.Filter;
using DAL.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pagedData,PaginationFilter filter,int totalRecords,IUriService service,string route) 
        {
            var response = new PagedResponse<List<T>>(pagedData, filter.PageNumber, filter.PageSize);
            double totalPages = totalRecords / (double)filter.PageSize;
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            response.NextPage =
                filter.PageNumber >= 1 && filter.PageNumber < roundedTotalPages
                ? service.GetPageUri(new PaginationFilter(filter.PageNumber + 1, filter.PageSize), route)
                : null;
            response.PreviousPage =
                filter.PageNumber - 1 >= 1 & filter.PageNumber <= roundedTotalPages
                ? service.GetPageUri(new PaginationFilter(filter.PageNumber - 1, filter.PageSize), route)
                : null;
            response.FirstPage = service.GetPageUri(new PaginationFilter(1, filter.PageSize), route);
            response.LastPage = service.GetPageUri(new PaginationFilter(roundedTotalPages, filter.PageSize), route);
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }
    }
}
