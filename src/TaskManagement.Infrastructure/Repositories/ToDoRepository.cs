using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;

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
            _context.Todos.Update(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<ToDo> GetByIdAsync(Guid id, string user)
        {
            return await _context.Todos
                                 .AsNoTracking()
                                 .FirstAsync(x => x.Id == id && x.User == user);
        }
    }
}