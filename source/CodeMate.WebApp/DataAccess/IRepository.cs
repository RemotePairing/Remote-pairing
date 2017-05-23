using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeMate.WebApp.DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> List { get; }
        T FindById(string Id);
    }
}