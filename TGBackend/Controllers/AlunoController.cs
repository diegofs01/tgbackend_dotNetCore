using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TGBackend.Models;
using System;
using TGBackend.Contexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TGBackend.Controllers
{
    [Route("api/aluno")]
    public class AlunoController : Controller
    {
        private readonly AlunoContext _context;

        public AlunoController(AlunoContext context)
        {
            _context = context;

            Console.WriteLine("Quantidade de Alunos: " + _context.aluno.Count());

        }

        // GET: api/aluno
        [HttpGet]
        public IEnumerable<Aluno> GetAll()
        {
            return _context.aluno.ToList();
        }

        // GET api/aluno/0030481421048
        [HttpGet("{ra}", Name = "GetAluno")]
        public IActionResult GetByRa(string ra)
        {
            var item = _context.aluno.FirstOrDefault(t => t.ra == ra);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/aluno
        [HttpPost]
        public IActionResult Create([FromBody] Aluno item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            _context.aluno.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetAluno", new { ra = item.ra }, item);
        }

        // PUT api/aluno/0030481421048
        [HttpPut("{ra}")]
        public IActionResult Update(string ra, [FromBody] Aluno item)
        {
            if(item == null || item.ra != ra)
            {
                return BadRequest();
            }

            var todo = _context.aluno.FirstOrDefault(t => t.ra == ra);
            if(todo == null)
            {
                return NotFound();
            }

            todo.nome = item.nome;
            todo.cpf = item.cpf;
            todo.rg = item.rg;
            todo.endereco = item.endereco;
            todo.numero = item.numero;
            todo.complemento = item.complemento;
            todo.bairro = item.bairro;
            todo.cidade = item.cidade;
            todo.estado = item.estado;
            todo.cep = item.cep;
            todo.numeroTelefone = item.numeroTelefone;
            todo.numeroCelular = item.numeroCelular;
            todo.email = item.email;
            todo.idCurso = item.idCurso;

            _context.aluno.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        // DELETE api/aluno/0030481421048
        [HttpDelete("{ra}")]
        public IActionResult Delete(string ra)
        {
            var todo = _context.aluno.FirstOrDefault(t => t.ra == ra);
            if(todo == null)
            {
                return NotFound();
            }

            _context.aluno.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
