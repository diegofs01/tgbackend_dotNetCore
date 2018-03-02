using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TGBackend.Contexts;
using TGBackend.Models;

namespace TGBackend.Controllers
{
    [Route("api/curso")]
    public class CursoController : Controller
    {
        private readonly CursoContext _context;

        public CursoController(CursoContext context)
        {
            _context = context;

            Console.WriteLine("Quantidade de Cursos: " + _context.curso.Count());

        }

        [HttpGet]
        public IEnumerable<Curso> GetAll()
        {
            return _context.curso.ToList();
        }

        [HttpGet("{id}", Name = "GetCurso")]
        public IActionResult GetById(int id)
        {
            var item = _context.curso.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Curso item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.curso.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCurso", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Curso item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var todo = _context.curso.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.id = item.id;
            todo.nome = item.nome;

            _context.curso.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.curso.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.curso.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
