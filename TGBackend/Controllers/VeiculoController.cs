using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGBackend.Contexts;
using TGBackend.Models;

namespace TGBackend.Controllers
{
    [Route("api/veiculo")]
    public class VeiculoController : Controller
    {
        private readonly VeiculoContext _context;

        public VeiculoController(VeiculoContext context)
        {
            _context = context;

            Console.WriteLine("Quantidade de Veiculos: " + _context.veiculo.Count());

        }

        [HttpGet]
        public IEnumerable<Veiculo> GetAll()
        {
            return _context.veiculo.ToList();
        }

        [HttpGet("{placa}", Name = "GetVeiculo")]
        public IActionResult GetById(string placa)
        {
            var item = _context.veiculo.FirstOrDefault(t => t.placa == placa);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Veiculo item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.veiculo.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetVeiculo", new { placa = item.placa }, item);
        }

        [HttpPut("{placa}")]
        public IActionResult Update(string placa, [FromBody] Veiculo item)
        {
            if (item == null || item.placa != placa)
            {
                return BadRequest();
            }

            var todo = _context.veiculo.FirstOrDefault(t => t.placa == placa);
            if (todo == null)
            {
                return NotFound();
            }

            todo.marca = item.marca;
            todo.modelo = item.modelo;
            todo.anoModelo = item.anoModelo;
            todo.anoFabricacao = item.anoFabricacao;
            todo.cor = item.cor;
            todo.paisFabricacao = item.paisFabricacao;
            todo.raAluno = item.raAluno;

            _context.veiculo.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            var todo = _context.veiculo.FirstOrDefault(t => t.placa == placa);
            if (todo == null)
            {
                return NotFound();
            }

            _context.veiculo.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
