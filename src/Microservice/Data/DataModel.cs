using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Data
{
    public class DataModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
