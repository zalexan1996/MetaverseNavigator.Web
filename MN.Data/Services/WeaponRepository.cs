using MN.Domain;

namespace MN.Data.Services
{
    public class MeleeWeaponTypeRepository : DataRepository<MeleeWeaponType>
    {
        public MeleeWeaponTypeRepository() : base(new Persona5Context())
        {

        }

        public List<string> GetAllTypes()
        {
            return List().Select(t=>t.Name).ToList();
        }

        public MeleeWeaponType? GetWeaponTypeByName(string name)
        {
            return _context.Set<MeleeWeaponType>().SingleOrDefault(m=>m.Name == name);
        }

        public void AddWeaponType(string name)
        {
            _context.Set<MeleeWeaponType>().Add(new MeleeWeaponType() {Name = name});
        }

        public void RemoveByName(string name)
        {
            MeleeWeaponType? entry = _context.Set<MeleeWeaponType>().FirstOrDefault(t=>t.Name == name);

            if (entry != null)
            {
                _context.Set<MeleeWeaponType>().Remove(entry);
            }
        }
    }


    public class RangedWeaponTypeRepository : DataRepository<RangedWeaponType>
    {
        public RangedWeaponTypeRepository() : base(new Persona5Context())
        {

        }

        public RangedWeaponType? GetWeaponTypeByName(string name)
        {
            return _context.Set<RangedWeaponType>().SingleOrDefault(m=>m.Name == name);
        }

        public List<string> GetAllTypes()
        {
            return List().Select(t=>t.Name).ToList();
        }

        public void AddWeaponType(string name)
        {
            _context.Set<RangedWeaponType>().Add(new RangedWeaponType() {Name = name});
        }

        
        public void RemoveByName(string name)
        {
            RangedWeaponType? entry = _context.Set<RangedWeaponType>().FirstOrDefault(t=>t.Name == name);

            if (entry != null)
            {
                _context.Set<RangedWeaponType>().Remove(entry);
            }
        }
    }
}