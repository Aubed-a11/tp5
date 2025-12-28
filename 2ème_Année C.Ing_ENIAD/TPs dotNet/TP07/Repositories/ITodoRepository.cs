using System.Collections.Generic;
using TP07.Models;

namespace TP07.Repositories
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();!;
        Todo? GetById(int id);
        Todo Add(Todo todo);
        bool Update(int id, Todo todo);
        bool Delete(int id);
    }
}
