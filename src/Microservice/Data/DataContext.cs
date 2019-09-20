using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Data
{
    public interface IDataContext
    {
        Task<IQueryable<DataModel>> GetAll(string filter, int Pagecount, int Pagesize);
        Task<DataModel> GetOneById(string id);
        Task<IQueryable<DataModel>> GetAllByLastUpdated(string filter, DateTime startdate, DateTime enddate, int pagecount, int pagesize);
        Task<IQueryable<DataModel>> GetAllByCreatedOn(string filter, DateTime startdate, DateTime enddate, int pagecount, int pagesize);
        Task<DataModel> Delete(DataModel model);
        Task<DataModel> Update(DataModel model);
        Task<DataModel> Add(DataModel model);
    }
    public sealed class DataContext : IDataContext
    {
        public Task<DataModel> Add(DataModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DataModel> Delete(DataModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DataModel>> GetAll(string filter, int Pagecount, int Pagesize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DataModel>> GetAllByCreatedOn(string filter, DateTime startdate, DateTime enddate, int pagecount, int pagesize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<DataModel>> GetAllByLastUpdated(string filter, DateTime startdate, DateTime enddate, int pagecount, int pagesize)
        {
            throw new NotImplementedException();
        }

        public Task<DataModel> GetOneById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DataModel> Update(DataModel model)
        {
            throw new NotImplementedException();
        }
    }
}
