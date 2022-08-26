using System;
using System.Collections;

namespace MN.Data.Services
{
    /// <summary>
    /// Our repository pattern for accessing the Persona5 database.
    /// </summary>
    public interface IDataRepository<T>
    {
        T? GetById(int id);
        List<T> List();
        List<T> List(ISpecification<T> specification);

        void Add(T entity);
        void Delete(T entity);

        void Save();
    }
}