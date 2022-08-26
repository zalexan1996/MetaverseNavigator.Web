using MN.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace MN.Data.Services
{
    public class ConfidantRepository : DataRepository<Confidant>
    {
        public ConfidantRepository() : base(new Persona5Context())
        {
        }

        public Confidant? GetByIdWithGameCharacter(int id)
        {
            return _context.Set<Confidant>().Include(c=>c.GameCharacter).SingleOrDefault(c=>c.Id == id);
        }
        public Confidant? GetConfidantByName(string name)
        {
            return _context.Set<Confidant>().Include(c=>c.GameCharacter).SingleOrDefault(c=>c.Name == name);
        }

        public Confidant? GetConfidantByGameCharacter(int id)
        {
            return _context.Set<Confidant>().Include(c=>c.GameCharacter).SingleOrDefault(c=>c.GameCharacterId == id);
        }

        public List<string> GetConfidantNames()
        {
            return _context.Set<Confidant>().Select(c=>c.Name).ToList();
        }


        public void AddConfidant(string name)
        {
            EntityEntry<Confidant> entity = _context.Set<Confidant>().Add(new Confidant {Name = name});
        }


        public void AddConfidantBenefit(int confidantId, string benefitName, string description, int rankUnlocked, string additionalRequirement)
        {
            _context.Set<ConfidantBenefit>().Add(new ConfidantBenefit()
            {
                AbilityName = benefitName,
                Description = description,
                RankUnlocked = rankUnlocked,
                ConfidantId = confidantId,
                AdditionalRequirement = additionalRequirement
            });
        }

        public IEnumerable<ConfidantBenefit> GetBenefitsByConfidantId(int confidantId)
        {
            return _context.Set<ConfidantBenefit>().Include(b=>b.Confidant).Where(b=>b.ConfidantId == confidantId).ToList();
        }

        public void DeleteConfidantBenefit(int confidantId, string abilityName)
        {
            ConfidantBenefit? benefit = _context.Set<ConfidantBenefit>().SingleOrDefault(b=>b.ConfidantId == confidantId && b.AbilityName == abilityName);
            if (benefit != null)
            {
               _context.Set<ConfidantBenefit>().Remove(benefit);
            }
        }


        public IEnumerable<ConfidantResponses> GetResponsesByConfidantId(int id)
        {
            return _context.Set<ConfidantResponses>().Where(r=>r.ConfidantId == id).OrderBy(r=>r.Rank).ThenBy(r=>r.ResponseOrder).ToList();
        }

        public void AddConfidantResponse(int confidantId, int rank, int order, string text)
        {
            Console.WriteLine($"Input was: {confidantId}, {rank}, {order}, {text}");
            _context.Set<ConfidantResponses>().Add(new ConfidantResponses
            {
                BoostAmount = 1,
                ConfidantId = confidantId,
                Rank = rank,
                ResponseOrder = order,
                ResponseText = text
            });
        }

        public void DeleteConfidantResponse(int id)
        {
            ConfidantResponses? response = _context.Set<ConfidantResponses>().Find(id);
            if (response != null)
            {
                _context.Set<ConfidantResponses>().Remove(response);
            }
        }

        public ConfidantBenefit? GetConfidantBenefitById(int id)
        {
            return _context.Set<ConfidantBenefit>().Find(id);
        }
    }
}