using System;
using Microservice.Data;
using System.Threading.Tasks;

namespace Microservice.Services
{
    public class GetService : IGetService
    {
        public async Task<DataModel> GetOneById(IDataContext dataContext, dynamic parameters)
        {
            var result = await dataContext.GetOneById(parameters.Id.ToString());
            return result;
        }

        public async Task<GetResult> GetAll(IDataContext dataContext, dynamic parameters)
        {
            var pagecount = parameters.Pagecount.ToString().AsInt(0);
            var pagesize = parameters.Pagesize.ToString().AsInt(25);

            var results = await dataContext.GetAll(parameters.Filter, pagecount, pagesize);
            var rtn = new GetResult(results, parameters.Filter, pagecount, pagesize);
            return rtn;
        }

        public async Task<GetResult> GetAllByLastUpdated(IDataContext dataContext, dynamic parameters)
        {
            var startdate = parameters.Startdate.ToString().AsDate(DateTime.Now.AddDays(-1));
            var enddate = parameters.Enddate.ToString().AsDate(DateTime.Now.AddMinutes(1));
            var pagecount = parameters.Pagecount.ToString().AsInt(0);
            var pagesize = parameters.Pagesize.ToString().AsInt(25);

            var results = await dataContext.GetAllByLastUpdated(parameters.Filter, startdate, enddate, pagecount, pagesize);
            var rtn = new GetResult(results, parameters.Filter, pagecount, pagesize);
            return rtn;
        }

        public async Task<GetResult> GetAllByCreatedOn(IDataContext dataContext, dynamic parameters)
        {
            var startdate = parameters.Startdate.ToString().AsDate(DateTime.Now.AddDays(-1));
            var enddate = parameters.Enddate.ToString().AsDate(DateTime.Now.AddMinutes(1));
            var pagecount = parameters.Pagecount.ToString().AsInt(0);
            var pagesize = parameters.Pagesize.ToString().AsInt(25);

            var results = await dataContext.GetAllByCreatedOn(parameters.Filter, startdate, enddate, pagecount, pagesize);
            var rtn = new GetResult(results, parameters.Filter, pagecount, pagesize);
            return rtn;
        }
    }
}
