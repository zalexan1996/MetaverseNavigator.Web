using System.Linq.Expressions;
using MN.Domain;

namespace MN.Data.Services
{
    /// <summary>
    /// Interface for all future Specifications. Probably just one.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        public Expression<Func<T, bool>> Where {get; }
        public List<Expression<Func<T,object>>> Includes {get; }


        //TODO: Add OrderBy
    }




    public class Specification<T> : ISpecification<T> where T : Persona5Base
    {
        public Specification(Expression<Func<T, bool>> where)
        {
            Where = where;
        }




        public Expression<Func<T, bool>> Where {get; }
        public List<Expression<Func<T,object>>> Includes {get; } = new List<Expression<Func<T, object>>>();




        protected virtual void AddInclude(Expression<Func<T,object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

    }
}