using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class Persona : Persona5Base
    {
        
        [Required][MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        public Confidant? Confidant { get; set; } = null;

        [Required]
        public int StartingLevel {get; set;}

        
    }
}
