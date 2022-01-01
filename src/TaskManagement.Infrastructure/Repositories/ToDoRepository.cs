using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.Queries;

namespace TaskManagement.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly TaskManagementContext _context;

        public ToDoRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ToDo toDo)
        {
            _context.Todos.Add(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDo toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ToDo> GetByIdAsync(Guid id, string user) =>
            await _context.Todos.AsNoTracking()
                                .FirstAsync(x => x.Id == id && x.User == user);

        public async Task<IEnumerable<ToDo>> GetAll(string user) =>
            await _context.Todos.AsNoTracking()
                                .Where(ToDoQueries.GetAll(user))
                                .OrderBy(x => x.StartedAt)
                                .ToListAsync();

        public async Task<IEnumerable<ToDo>> GetAllDone(string user) =>
            await _context.Todos.AsNoTracking()
                                .Where(ToDoQueries.GetAllDone(user))
                                .OrderBy(x => x.StartedAt)
                                .ToListAsync();
        public async Task<IEnumerable<ToDo>> GetAllUndone(string user) =>
            await _context.Todos.AsNoTracking()
                                .Where(ToDoQueries.GetAllUndone(user))
                                .OrderBy(x => x.StartedAt)
                                .ToListAsync();

        public async Task<IEnumerable<ToDo>> GetByPeriod(string user, DateTime date, bool done) =>
            await _context.Todos.AsNoTracking()
                                .Where(ToDoQueries.GetByPeriod(user, date, done))
                                .OrderBy(x => x.StartedAt)
                                .ToListAsync();
    }
}