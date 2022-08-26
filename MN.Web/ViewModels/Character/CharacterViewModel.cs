using MN.Domain;

namespace MN.Web.ViewModels
{
    public class CharacterBundle
    {
        public GameCharacter? GameCharacter {get; set;}
        public BattleCharacter? BattleCharacter {get; set;}
        public Confidant? Confidant {get; set;}
    }
    public class CharacterViewModel
    {
        public IEnumerable<CharacterBundle>? CharacterBundles {get; set;}

    }
}