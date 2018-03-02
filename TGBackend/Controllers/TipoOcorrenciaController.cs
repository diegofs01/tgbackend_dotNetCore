using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TGBackend.Contexts;
using TGBackend.Models;

namespace TGBackend.Controllers
{
    [Route("api/tipoOcorrencia")]
    public class TipoOcorrenciaController : Controller
    {
        private readonly TipoOcorrenciaContext _context;

        public TipoOcorrenciaController(TipoOcorrenciaContext context)
        {
            _context = context;

            Console.WriteLine("Quantidade de Tipos de Ocorrencia: " + _context.tipoOcorrencia.Count());

        }

        [HttpGet]
        public IEnumerable<TipoOcorrencia> GetAll()
        {
            return _context.tipoOcorrencia.ToList();
        }

        [HttpGet("{id}", Name = "GetTipoOcorrencia")]
        public IActionResult GetById(int id)
        {
            var item = _context.tipoOcorrencia.FirstOrDefault(t => t.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TipoOcorrencia item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.tipoOcorrencia.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTipoOcorrencia", new { id = item.id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TipoOcorrencia item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var todo = _context.tipoOcorrencia.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.id = item.id;
            todo.nome = item.nome;

            _context.tipoOcorrencia.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _context.tipoOcorrencia.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.tipoOcorrencia.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}