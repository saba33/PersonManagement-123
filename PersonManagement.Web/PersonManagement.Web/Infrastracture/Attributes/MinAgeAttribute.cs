using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonManagement.Web.Infrastracture.Attributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int age)
        {
            _minAge = age;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime)
            {
                var dateOfBirth = (DateTime)value;
                var age = (DateTime.Today - dateOfBirth).Days / 365;

                if(age < _minAge)
                {
                    return new ValidationResult("go home baby");
                }

                return ValidationResult.Success;
            }

            return base.IsValid(value, validationContext);
        }
    }
}
