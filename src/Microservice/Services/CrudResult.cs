using Microservice.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microservice.Services
{
    public sealed class CrudResult
    {
        public CrudResult(ValidationResult[] errors, DataModel result = null)
        {
            Errors = errors;
            Result = result;
        }
        public bool Success => CalcSuccess();              

        public ValidationResult[] Errors { get; }
        public DataModel Result { get; }

        private bool CalcSuccess()
        {
            var rtn = Errors == null || Errors.Count() == 0 ;
            return rtn;
        }

    }
}
