using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microservice.Data;

namespace Microservice.Events
{

    public sealed class EventHub : IEventHub
    {
        public async Task OnCreated(DataModel model)
        {
            await Task.CompletedTask;
        }

        public async Task OnUpdated(DataModel model)
        {
            await Task.CompletedTask;
        }

        public async Task OnDeleted(DataModel model)
        {
            await Task.CompletedTask;
        }
    }
}
