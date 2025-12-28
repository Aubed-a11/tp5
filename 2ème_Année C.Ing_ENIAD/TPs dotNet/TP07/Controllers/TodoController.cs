using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP07.Models;        
using TP07.Repositories;  

namespace TP07.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        // Injection de dépendance du repository
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // Action pour récupérer tous les Todo
        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return _todoRepository.GetAll();
        }

        // Récupérer un Todo par son Id
        [HttpGet("{id}")]
        public ActionResult<Todo> GetById([FromRoute] int id)
        {
            var todo = _todoRepository.GetById(id); // Méthode à implémenter dans le repository
            if (todo == null)
            {
                return NotFound(); 
            }
            return Ok(todo);
        }

        // Ajouter un nouveau Todo
        [HttpPost]
        public ActionResult<Todo> Create([FromBody] Todo todo)
        {
            if (todo == null || string.IsNullOrWhiteSpace(todo.Title))
            {
                return BadRequest("Le Todo est invalide.");
            }

            _todoRepository.Add(todo); // Méthode à implémenter dans le repository

           
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // Mettre à jour 
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Todo todo)
        {
            if (todo == null || string.IsNullOrWhiteSpace(todo.Title))
            {
                return BadRequest("Le Todo est invalide.");
            }

            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound(); 
            }

            _todoRepository.Update(id, todo); 

            return NoContent(); 
        }

        // Supprimer un Todo par id
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var existingTodo = _todoRepository.GetById(id);
            if (existingTodo == null)
            {
                return NotFound(); 
            }

            _todoRepository.Delete(id); 

            return NoContent(); 
        }

    }
}
