using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Services.ExtendMethods
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class AcceptTermsRequiredAttribute : ValidationAttribute
    {
        private string _message;
        public AcceptTermsRequiredAttribute(string ErrorMessage)
        {
            _message = ErrorMessage;
        }

        protected override ValidationResult IsValid(object? obj, ValidationContext validationContext)
        {            
            if (obj == null || obj is not bool || (bool)obj == false)
                return new ValidationResult(_message);
            return ValidationResult.Success;
        }
               
    }
}
