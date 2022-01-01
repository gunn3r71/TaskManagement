using System;
using System.Linq.Expressions;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Queries
{
    public static class ToDoQueries
    {
        public static Expression<Func<ToDo, bool>> GetAll(string user) =>
            x => x.User == user;

        public static Expression<Func<ToDo, bool>> GetAllDone(string user) =>
            x => x.User == user && x.Done;

        public static Expression<Func<ToDo, bool>> GetAllUndone(string user) =>
            x => x.User == user && !x.Done;

        public static Expression<Func<ToDo, bool>> GetByPeriod(string user, DateTime startDate, bool done) =>
            x => x.User == user && x.StartedAt.Date == startDate.Date && x.Done == done;

    }
}