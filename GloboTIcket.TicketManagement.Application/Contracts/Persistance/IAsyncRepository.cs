using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTIcket.TicketManagement.Application.Contracts.Persistance
{
    //Generic Repository
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        //We can have SaveAsync and Save Methods Here for Manual Transactions
    }
}