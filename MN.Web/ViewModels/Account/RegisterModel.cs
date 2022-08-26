using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MN.Web.Annotations;


namespace MN.Domain
{
    public class RegisterModel
    {

        [RequireUserNotExistAttribute()]
        public string Username {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password {get; set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password must match.")]
        public string ConfirmPassword {get; set;}



        public string ReturnUrl {get; set;} = "/";
    }
}