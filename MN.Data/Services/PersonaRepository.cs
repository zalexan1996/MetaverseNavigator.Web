using MN.Domain;
using Microsoft.EntityFrameworkCore;

namespace MN.Data.Services
{
    public class PersonaRepository : DataRepository<Persona>
    {
        public PersonaRepository() : base(new Persona5Context())
        {

        }

        public Persona? GetPersonaByName(string name)
        {
            return _context.Set<Persona>().SingleOrDefault(p=>p.Name == name);
        }

        public List<Persona> GetPersonasWithConfidant(string includeConfidantName = "")
        {
            return _context.Set<Persona>().Include(p=>p.Confidant).Where(p=>p.Confidant.Name.Contains(includeConfidantName)).ToList();
        }

        public void AddPersona(string name, string confidant, int startingLevel)
        {
            Confidant? confidantObj = _context.Set<Confidant>().FirstOrDefault(a=>a.Name == confidant);
            if (confidantObj != null)
            {
                _context.Set<Persona>().Add(new Persona() {Name = name, Confidant = confidantObj, StartingLevel = startingLevel});
            }
        }

        public void RemovePersona(string name)
        {
            Persona? personaObj = _context.Set<Persona>().FirstOrDefault(a=>a.Name == name);
            if (personaObj != null)
            {
                _context.Set<Persona>().Remove(personaObj);
            }
        }
    }
}