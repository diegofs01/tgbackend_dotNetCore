using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TGBackend.Contexts;
using TGBackend.Models;

namespace TGBackend.Controllers
{
    [Route("api/ocorrencia")]
    public class OcorrenciaController : Controller
    {
        private readonly OcorrenciaContext _context;

        private readonly List<TipoOcorrencia> _tiposOcorrencias;

        public OcorrenciaController(OcorrenciaContext context)
        {
            _context = context;

            Console.WriteLine("");
            Console.WriteLine("Quantidade de Ocorrencias: " + _context.ocorrencia.Count());
            Console.WriteLine("");

            _tiposOcorrencias = _context.tipoOcorrencia.ToList();
        }

        [HttpGet]
        public IEnumerable<Ocorrencia> GetAll()
        {
            var ocorrencias = _context.ocorrencia.ToList();

            Console.WriteLine("");
            ocorrencias.ForEach(ocorrencia => Console.WriteLine("numero: " + ocorrencia.numero + ", placa: " + ocorrencia.placaVeiculo + ", data: " + ocorrencia.data.ToShortDateString() + ", hora: " + ocorrencia.hora + ", tipo: " + ocorrencia.idTipoOcorrencia));
            Console.WriteLine("");

            ocorrencias.ForEach(ocorrencia =>
            {
                ocorrencia.tipoOcorrencia = _tiposOcorrencias.First(to => to.id == ocorrencia.idTipoOcorrencia);
            });

            return ocorrencias;
        }

        [HttpGet("{numero}", Name = "GetOcorrencia")]
        public IActionResult GetByDados(int numero)
        {
            Console.WriteLine("");
            Console.WriteLine("numero: " + numero);
            Console.WriteLine("");

            var item = _context.ocorrencia.FirstOrDefault(t => t.numero == numero);

            if (item == null)
            {
                return NotFound();
            }

            item.tipoOcorrencia = _tiposOcorrencias.FirstOrDefault(to => to.id == item.idTipoOcorrencia);

            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ocorrencia item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Console.WriteLine("");
            Console.WriteLine("verificarVeiculo: " + verificarVeiculo(item.placaVeiculo));
            Console.WriteLine("");

            if (verificarVeiculo(item.placaVeiculo) == 1)
            {
                item.veiculoCadastrado = true;
            } else
            {
                item.veiculoCadastrado = false;
            }

            _context.ocorrencia.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetOcorrencia", new { numero = item.numero }, item);
        }

        [HttpPut("{numero}")]
        public IActionResult Update(int numero, [FromBody] Ocorrencia item)
        {
            if (item == null || item.numero != numero)
            {
                return BadRequest();
            }

            var todo = _context.ocorrencia.FirstOrDefault(t => t.numero == numero);
            if (todo == null)
            {
                return NotFound();
            }

            todo.descricao = item.descricao;
            todo.tipoOcorrencia = item.tipoOcorrencia;

            _context.ocorrencia.Update(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        [HttpDelete("{numero}")]
        public IActionResult Delete(int numero)
        {
            var todo = _context.ocorrencia.FirstOrDefault(t => t.numero == numero);
            if (todo == null)
            {
                return NotFound();
            }

            _context.ocorrencia.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }

        public int verificarVeiculo(String placa)
        {
            int resultado = 0;

            var veiculo = _context.veiculo.Find(placa);

            if (veiculo != null)
                resultado = 1;

            return resultado;
        }
    }
}
