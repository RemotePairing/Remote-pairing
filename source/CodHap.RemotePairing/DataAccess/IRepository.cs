namespace CodHap.RemotePairing.DataAccess
{
    using System.Collections.Generic;

    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> List { get; }
        T FindById(string id);
    }
}