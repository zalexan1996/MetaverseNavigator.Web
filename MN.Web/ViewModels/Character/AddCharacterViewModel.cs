using MN.Domain;
using System.ComponentModel.DataAnnotations;
using MN.Web.Annotations;

namespace MN.Web.ViewModels
{
    public class AddCharacterViewModel
    {
        [Required(ErrorMessage = "Name for Character is required")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Age for Character is required. If inapplicable, choose 0")]
        public int Age {get; set;}

        [Required(ErrorMessage = "Occupation for Character is required")]
        public string Occupation {get; set;}

        public bool IsBattleCharacter {get; set;}

            [RequiredIf(nameof(IsBattleCharacter), true, ErrorMessage = "Codename for battle character is required")]
            public string? Codename {get; set;}

            [RequiredIf(nameof(IsBattleCharacter), true, ErrorMessage = "Starting Persona for battle character is required")]
            public string? StartingPersonaName {get; set;}
            
            [RequiredIf(nameof(IsBattleCharacter), true, ErrorMessage = "Awakened Persona for battle character is required")]
            public string? AwakenedPersonaName {get; set;}
            
            [RequiredIf(nameof(IsBattleCharacter), true, ErrorMessage = "Melee Weapon Type for battle character is required")]
            public string? MeleeWeaponTypeName {get; set;}
            
            [RequiredIf(nameof(IsBattleCharacter), true, ErrorMessage = "Ranged Weapon Type for battle character is required")]
            public string? RangedWeaponTypeName { get; set; }


        public Boolean IsConfidantCharacter {get; set;}
        
            [RequiredIf(nameof(IsConfidantCharacter), true, ErrorMessage = "ConfidantName for confidant character is required")]
            public string? ConfidantName {get; set;}





        public IEnumerable<Confidant> Confidants {get; set;} = new List<Confidant>();
        public IEnumerable<Persona> Personas {get; set;} = new List<Persona>();

        public IEnumerable<string> MeleeWeaponTypes {get; set;} = new List<string>();
        public IEnumerable<string> RangedWeaponTypes {get; set;} = new List<string>();
    }
}