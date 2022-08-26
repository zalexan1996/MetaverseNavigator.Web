using MN.Data;
using MN.Domain;

using Microsoft.EntityFrameworkCore;


namespace MN.Data.Services
{

    public class DataRepository<T> : IDataRepository<T> where T : Persona5Base
    {
        protected Persona5Context _context;

        public DataRepository(Persona5Context context)
        {
            _context = context;
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> List(ISpecification<T> specification)
        {
            var withInclude = specification.Includes.Aggregate(_context.Set<T>().AsQueryable(), (current, include) => current.Include(include));

            return withInclude.Where(specification.Where).ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}