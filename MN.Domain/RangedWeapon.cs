using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class RangedWeapon : Persona5Base
    {
        
        [Required]
        public RangedWeaponType? RangedWeaponType { get; set; } = null;
        
        [Required][MaxLength(100)]
        public string Name { get; set; } = "";
        
        [Required]
        public int Attack { get; set; } = 1;
        
        [Required]
        public int Accuracy { get; set; } = 1;
        
        [Required]
        public int Rounds { get; set; } = 1;

        public string Effect { get; set; } = "";
        
        [Required]
        public int Price { get; set; } = 0;
    }
}
