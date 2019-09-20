using Nancy;
using Microservice.Data;
using Microservice.Services;

namespace Microservice.Modules
{
    public sealed class GetModule : NancyModule
    {
        
        public GetModule(IDataContext dataContext, IGetService getService)
        {
            Get("/api/v1/widgets/all/{Filter}/{Pagecount}/{Pagesize}", async parameters =>
            {
                return await getService.GetAll(dataContext, parameters);
            });

            Get("/api/v1/widgets/lastupdated/{Startdate}/{Enddate}/{Filter}/{Pagecount}/{Pagesize}", async parameters =>
            {
                return await getService.GetAllByLastUpdated(dataContext, parameters);
            });

            Get("/api/v1/widgets/createdOn/{Startdate}/{Enddate}/{Filter}/{Pagecount}/{Pagesize}", async parameters =>
            {
                return await getService.GetAllByCreatedOn(dataContext, parameters);
            });

            Get("/api/v1/widgets/{Id}/", async parameters =>
            {
                return await getService.GetOneById(dataContext, parameters);
            });

        }

        
    }
}
