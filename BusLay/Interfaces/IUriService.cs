using DAL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter,string route);
    }
}
