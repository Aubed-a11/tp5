using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TP07.Models;
using TP07.Repositories;

namespace TP07.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private static List<Todo> _todos = new List<Todo>();

        private static int _nextId = 1;

        public InMemoryTodoRepository()
        {
            if (_todos.Count == 0)
            {
                _todos.Add(new Todo { Id = _nextId++, Title = "Apprendre .NET", IsDone = false });
                _todos.Add(new Todo { Id = _nextId++, Title = "Faire le TP de GI", IsDone = true });
                _todos.Add(new Todo { Id = _nextId++, Title = "Réviser pour l'examen", IsDone = false });
            }
        }
        public IEnumerable<Todo> GetAll()
        {
            return _todos;
        }
        public Todo? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public Todo Add(Todo todo)
        {
            todo.Id = _nextId++;
            _todos.Add(todo);
            return todo;
        }

        public bool Update(int id, Todo updatedTodo)
        {
            var existingTodo = GetById(id);
            if (existingTodo == null)
                return false;

            existingTodo.Title = updatedTodo.Title;
            existingTodo.IsDone = updatedTodo.IsDone;

            return true;
        }

        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo == null)
                return false;

            return _todos.Remove(todo);
        }
    }
}
