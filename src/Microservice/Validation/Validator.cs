using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microservice.Data;

namespace Microservice.Validation
{
    public class Validator : IValidator
    {
        private readonly IUpdateValidator updateValidator;
        private readonly ICreateValidator createValidator;
        private readonly IDeleteValidator deleteValidator;

        public Validator(IUpdateValidator updateValidator, ICreateValidator createValidator , IDeleteValidator deleteValidator)
        {
            this.updateValidator = updateValidator;
            this.createValidator = createValidator;
            this.deleteValidator = deleteValidator;
        }

        public bool TryValidateUpdate(DataModel model, List<ValidationResult> validationResults)
        {
            var result = updateValidator.ValidateModel(model);
            validationResults.AddRange(result);
            var rtn = (result.Any() == false);
            return rtn;
        }

        public bool TryValidateDelete(DataModel model, List<ValidationResult> validationResults)
        {
            var result = deleteValidator.ValidateModel(model);
            validationResults.AddRange(result);
            var rtn = (result.Any() == false);
            return rtn;
        }

        public bool TryValidateCreate(DataModel model, List<ValidationResult> validationResults)
        {
            var result = createValidator.ValidateMode3l(model);
            validationResults.AddRange(result);
            var rtn = (result.Any() == false);
            return rtn;
        }
    }
}
