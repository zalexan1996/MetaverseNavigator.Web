using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class User : Persona5Base
    {
        [Required()]
        [MaxLength(20)]
        public string Username {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        

        public UserType UserType {get; set;}
        public int UserTypeId {get; set;}

        public IEnumerable<UserHistory> UserHistories {get; set;} = new List<UserHistory>();
    }
}