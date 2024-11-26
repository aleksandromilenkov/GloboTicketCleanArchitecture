using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<IReadOnlyList<T>> ListAllAsync();
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}
