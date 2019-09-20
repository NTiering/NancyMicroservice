using Nancy;
using Nancy.ModelBinding;
using Microservice.Data;
using Microservice.Events;
using Microservice.Validation;
using Microservice.Config;
using Microservice.Services;

namespace Microservice.Modules
{
    public sealed class CrudModule : NancyModule
    {
        public CrudModule(IDataContext dataContext, IValidator widgetValidator, IEventHub eventHub, ICrudService crudService, ISettings settings)
        {
            Post($"/api/v1/{settings.EntityName}/", async parameters =>
            {
                var rtn = await crudService.Add(dataContext, MakeModel(), widgetValidator);
                if (rtn.Success) await eventHub.OnCreated(rtn.Result);
                return rtn;
            });

            Put($"/api/v1/{settings.EntityName}/", async parameters =>
            {
                var rtn = await crudService.Update(dataContext, MakeModel(), widgetValidator);
                if (rtn.Success) await eventHub.OnUpdated(rtn.Result);
                return rtn;
            });

            Delete($"/api/v1/{settings.EntityName}/", async parameters =>
            {
                var rtn = await crudService.Delete(dataContext, MakeModel(), widgetValidator);
                if (rtn.Success) await eventHub.OnDeleted(rtn.Result);
                return rtn;
            });
        }

        private DataModel MakeModel()
        {
            var model = this.Bind<DataModel>();
            return model;
        }
    }
}

