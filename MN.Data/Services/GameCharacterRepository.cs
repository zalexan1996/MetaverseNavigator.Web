using MN.Domain;

namespace MN.Data.Services
{
    public class GameCharacterRepository : DataRepository<GameCharacter>
    {
        public GameCharacterRepository() : base(new Persona5Context())
        {
            
        }

        public GameCharacter? GetGameCharacterByName(string name)
        {
            return _context.Set<GameCharacter>().SingleOrDefault(g=>g.Name == name);
        }
        
        public void DeleteById(int gameCharacterId)
        {
            GameCharacter? gameCharacter = _context.Set<GameCharacter>().Find(gameCharacterId);
            if (gameCharacter != null)
            {
                _context.Remove(gameCharacter);
            }
        }
    }
}