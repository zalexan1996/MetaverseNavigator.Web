using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MN.Web.Annotations
{

    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _fieldName;
        private readonly bool _expectedValue;
        private readonly bool _isRequired;
        
        public RequiredIfAttribute(string fieldName, bool expectedValue)
        {
            _fieldName = fieldName;
            _expectedValue = expectedValue;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext vContext)
        {
            object? otherValue = vContext.ObjectType.GetProperty(_fieldName, BindingFlags.Instance | BindingFlags.Public)?.GetValue(vContext.ObjectInstance);

            if (otherValue?.ToString() == _expectedValue.ToString())
            {
                if (value == null)
                {
                    return new ValidationResult(ErrorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}