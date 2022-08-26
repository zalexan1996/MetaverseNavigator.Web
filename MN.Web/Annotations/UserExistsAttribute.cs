using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MN.Data;
using MN.Data.Services;

namespace MN.Web.Annotations
{
    public class RequireUserNotExistAttribute : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext vContext)
        {
            IPersonaService? personaService = vContext.GetService<IPersonaService>();


            if (personaService == null) return new ValidationResult("Failed to access Persona Service");
            if (value == null) return new ValidationResult("Failed to validate null property");
            if (personaService.UserRepository.UserExists(value.ToString()!)) return new ValidationResult("Username already exists.");


            return ValidationResult.Success;
        }
    }
}