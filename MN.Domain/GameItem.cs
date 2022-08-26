using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class GameItem : Persona5Base
    {
        
        [Required][MaxLength(100)]
        public string Name { get; set; } = "";

    }
}
