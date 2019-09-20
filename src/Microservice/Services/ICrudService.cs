using System.Threading.Tasks;
using Microservice.Data;
using Microservice.Validation;

namespace Microservice.Services
{
    public interface ICrudService
    {
        Task<CrudResult> Add(IDataContext dataContext, DataModel model, IValidator validator);
        Task<CrudResult> Delete(IDataContext dataContext, DataModel model, IValidator validator);
        Task<CrudResult> Update(IDataContext dataContext, DataModel model, IValidator validator);
    }
}