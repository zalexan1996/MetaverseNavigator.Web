using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class GameCharacter : Persona5Base
    {
        [Required][MaxLength(100)]
        public string Name { get; set; } = "";
        
        [Required][MaxLength(200)]
        public string Occupation { get; set; } = "";
        
        public int Age { get; set; } = 0;

    }
}
