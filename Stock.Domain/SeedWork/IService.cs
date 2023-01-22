using Stocking.Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocking.Domain.SeedWork
{
    public interface IService<T> where T : IAggregateRoot
    {
        Task<Article> AddAsync(T entity);

        void Update(T entity);

        Task<T> GetByReference(string reference);
        Task<IEnumerable<T>> GetAll();
        Task<bool> ExistReferenceAsync(string reference);
        Task DeleteAsync(T entity);
        Task DeleteByReferenceAsync(string reference);
        Task<Article> GetById(string reference);
    }
}
