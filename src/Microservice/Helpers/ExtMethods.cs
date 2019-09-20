using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Microservice.Helpers
{
    public static class ExtMethods
    {
        public static int AsInt(this string s, int defaultValue)
        {
            var rtn = int.TryParse(s, out var t) ? t : defaultValue;
            return rtn;
        }

        public static DateTime AsDate(this string s, DateTime defaultValue)
        {
            var rtn = DateTime.TryParse(s, out var t) ? t : defaultValue;
            return rtn;
        }

        public static bool AsBool(this string s)
        {
            var v = s.ToLower().Trim();
            var rtn = (v == "t") || (v == "true") || (v == "yes") || (v == "1");
            return rtn;
        }

        public static List<ValidationResult> ToResults(this IList<FluentValidation.Results.ValidationFailure> rtn)
        {
            var result = rtn.Select(x => new ValidationResult(x.ErrorMessage, new[] { x.PropertyName })).ToList();
            return result;
        }
    }
}
