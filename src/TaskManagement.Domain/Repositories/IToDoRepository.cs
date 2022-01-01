﻿using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Repositories
{
    public interface IToDoRepository
    {
        Task AddAsync(ToDo toDo);
        Task UpdateAsync(ToDo toDo);
    }
}