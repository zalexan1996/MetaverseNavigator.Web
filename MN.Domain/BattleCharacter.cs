using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MN.Domain
{
    public class BattleCharacter : Persona5Base
    {

        [Required()]
        public GameCharacter? GameCharacter { get; set; } = null;
        public int GameCharacterId {get; set;}


        // The Metaverse codename of the character ("Skull")
        [Required(ErrorMessage = "Please enter a codename.")]
        [MaxLength(100)]
        public string Codename { get; set; } = "";

        // The Id of the Persona before awakening
        [ForeignKey("BasePersonaId")][Required()]
        public Persona? BasePersona { get; set; } = null;

        // The Id of this Character's Persona after awakening
        [ForeignKey("AwakenedPersonaId")][Required()]
        public Persona? AwakenedPersona { get; set; } = null;

        public int BasePersonaId { get; set; }
        public int AwakenedPersonaId { get; set; }

        // The Id of this Character's melee weapon type
        [Required()]
        public MeleeWeaponType? MeleeWeaponType { get; set; } = null;
        public int MeleeWeaponTypeId {get; set;}

        // The Id of this Character's ranged weapon type.
        [Required()]
        public RangedWeaponType? RangedWeaponType { get; set; } = null;
        public int RangedWeaponTypeId {get; set;}



    }
}
