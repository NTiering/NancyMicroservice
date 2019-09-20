using System;
using System.Collections.Generic;
using Microservice.Data;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microservice.Validation;

namespace Microservice.Services
{
    public class CrudService : ICrudService
    {
        public async Task<CrudResult> Add(IDataContext dataContext, DataModel model, IValidator validator)
        {
            var errors = new List<ValidationResult>();
            if (validator.TryValidateCreate(model, errors))
            {
                model.CreatedOn = DateTime.Now;
                model.LastUpdatedOn = model.CreatedOn;
                model = await dataContext.Add(model);
                return new CrudResult(errors.ToArray(), model);
            }
            else
            {
                return new CrudResult(errors.ToArray(), null);
            }
        }

        public async Task<CrudResult> Update(IDataContext dataContext, DataModel model, IValidator validator)
        {
            var errors = new List<ValidationResult>();
            if (validator.TryValidateUpdate(model, errors))
            {
                model.LastUpdatedOn = model.CreatedOn;
                model = await dataContext.Update(model);
                return new CrudResult(errors.ToArray(), model);
            }
            else
            {
                return new CrudResult(errors.ToArray(), null);
            }
        }

        public async Task<CrudResult> Delete(IDataContext dataContext, DataModel model, IValidator validator)
        {
            var errors = new List<ValidationResult>();
            if (validator.TryValidateDelete(model, errors))
            {
                model.LastUpdatedOn = model.CreatedOn;
                model = await dataContext.Delete(model);
                return new CrudResult(errors.ToArray(), model);
            }
            else
            {
                return new CrudResult(errors.ToArray(), null);
            }
        }
    }
}