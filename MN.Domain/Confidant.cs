using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MN.Domain
{
    public class Confidant : Persona5Base
    {
        [Required()][MaxLength(100)]
        public string Name { get; set; } = "";

        [ForeignKey("GameCharacterId")]
        public GameCharacter? GameCharacter {get; set;}

        public int? GameCharacterId {get; set;}
        
        public string? CardUrl {get; set;}
    }
}
