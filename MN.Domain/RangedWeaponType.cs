using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class RangedWeaponType : Persona5Base
    {
        
        [Required][MaxLength()]
        public string Name { get; set; } = "";
    }
}
