using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Microservice.Data;
using Microservice.Helpers;

namespace Microservice.Validation
{ 
    public class UpdateValidator : AbstractValidator<DataModel>, IUpdateValidator
    {
        public UpdateValidator()
        {
            RuleFor(model => model).NotNull();
        }
        public ICollection<ValidationResult> ValidateModel(DataModel model)
        {
            if (model == null) return new[] { new ValidationResult("null_model") };
            var rtn = Validate(model).Errors.ToResults();
            return rtn;
        }
    }
}
