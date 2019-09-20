using System.Threading.Tasks;
using Microservice.Data;

namespace Microservice.Services
{
    public interface IGetService
    {
        Task<GetResult> GetAll(IDataContext dataContext, dynamic parameters);
        Task<GetResult> GetAllByCreatedOn(IDataContext dataContext, dynamic parameters);
        Task<GetResult> GetAllByLastUpdated(IDataContext dataContext, dynamic parameters);
        Task<DataModel> GetOneById(IDataContext dataContext, dynamic parameters);
    }
}