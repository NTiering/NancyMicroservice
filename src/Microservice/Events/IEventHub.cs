using System.Threading.Tasks;
using Microservice.Data;

namespace Microservice.Events
{
    public interface IEventHub
    {
        Task OnCreated(DataModel model);
        Task OnDeleted(DataModel model);
        Task OnUpdated(DataModel model);
    }
}