using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class UserHistory : Persona5Base
    {
        public User User {get; set;}
        public int UserId {get; set;}

        [Required]
        public DateTime DateAccessed {get; set;}
    }
}