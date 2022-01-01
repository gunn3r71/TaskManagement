using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repositories
{
    public interface IToDoRepository
    {
        Task AddAsync(ToDo toDo);
        Task UpdateAsync(ToDo toDo);
        Task<ToDo> GetByIdAsync(Guid id, string user);
        Task<IEnumerable<ToDo>> GetAll(string user);
        Task<IEnumerable<ToDo>> GetAllDone(string user);
        Task<IEnumerable<ToDo>> GetAllUndone(string user);
        Task<IEnumerable<ToDo>> GetByPeriod(string user, DateTime date, bool done);
    }
}