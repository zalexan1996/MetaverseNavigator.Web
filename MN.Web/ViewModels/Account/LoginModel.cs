using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MN.Domain
{
    public class LoginModel
    {
        public string Username {get; set;}
        public string Password {get; set;}
        public bool RememberLogin {get; set;}
        public string ReturnUrl {get; set;} = "/";

    }
}