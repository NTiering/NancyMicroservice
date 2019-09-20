using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microservice.Data;

namespace Microservice.Services
{
    public class GetResult
    {
        public IQueryable<DataModel> Results { get; }
        public string Filter { get; }
        public int PageCount { get; }
        public int PageSize { get; }
        public GetResult(IQueryable<DataModel> results, string filter, int pageCount, int pageSize)
        {
            Results = results;
            Filter = filter;
            PageCount = pageCount;
            PageSize = pageSize;
        }
    }
}
