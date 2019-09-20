using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microservice.Data;
using FluentValidation;
using System.Linq;
using Microservice.Helpers;

namespace Microservice.Validation
{
    public class CreateValidator : AbstractValidator<DataModel> , ICreateValidator
    {
        public CreateValidator()
        {
            RuleFor(model => model).NotNull();
        }
        public ICollection<ValidationResult> ValidateMode3l(DataModel model)
        {
            if (model == null) return new[] { new ValidationResult("null_model") };
            var rtn = Validate(model).Errors.ToResults();
            return rtn;
        }        
    }
}
