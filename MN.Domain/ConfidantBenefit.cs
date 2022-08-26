using System.ComponentModel.DataAnnotations;

namespace MN.Domain
{
    public class ConfidantBenefit : Persona5Base
    {
        [Required]
        public int RankUnlocked { get; set; } = 0;

        [Required][MaxLength(100)]
        public string AbilityName { get; set; } = "";

        [Required][MaxLength(500)]
        public string Description { get; set; } = "";

        [MaxLength(250)]
        public string ? AdditionalRequirement {get; set;} = "";


        [Required]
        public Confidant? Confidant { get; set; } = null;

        [Required]
        public int ConfidantId {get; set;}
    }
}
