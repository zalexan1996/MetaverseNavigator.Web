using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class UserType : Persona5Base
    {

        [Required]
        [MaxLength(50)]
        public string TypeName {get; set;}

        // Navigation property for users in this user type.
        public IEnumerable<User> Users {get; set;} = new List<User>();
    }
}