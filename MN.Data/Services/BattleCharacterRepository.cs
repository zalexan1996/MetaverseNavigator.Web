using MN.Domain;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MN.Data.Services
{
    public class BattleCharacterRepository : DataRepository<BattleCharacter>
    {
        public BattleCharacterRepository() : base(new Persona5Context())
        {
            
        }

        public IEnumerable<BattleCharacter> ListWithGameCharacter(Expression<Func<BattleCharacter, bool>> where)
        {
            return List(new Specification<BattleCharacter>(where)
            {
                Includes = { 
                    b=>b.GameCharacter
                }
            });
        }

        public void DeleteById(int battleCharacterId)
        {
            BattleCharacter? battleCharacter = _context.Set<BattleCharacter>().Find(battleCharacterId);
            
            if (battleCharacter != null)
            {
                _context.Remove(battleCharacter);
            }
        }

        public BattleCharacter? FindByGameCharacterId(int gameCharacterId)
        {
            return _context.Set<BattleCharacter>().SingleOrDefault(b=>b.GameCharacter.Id == gameCharacterId);
        }
        public BattleCharacter? FindByGameCharacterIdIncludeAll(int gameCharacterId)
        {
            return _context.Set<BattleCharacter>().Include(b=>b.AwakenedPersona).Include(b=>b.BasePersona).Include(b=>b.MeleeWeaponType).Include(b=>b.RangedWeaponType).SingleOrDefault(b=>b.GameCharacter.Id == gameCharacterId);
        }
    }
}