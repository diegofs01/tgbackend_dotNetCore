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
            ocorrencias.ForEach(ocorrencia => Console.WriteLine("placa: " + ocorrencia.placaVeiculo + ", data: " + ocorrencia.data.ToShortDateString() + ", hora: " + ocorrencia.hora + ", tipo: " + ocorrencia.idTipoOcorrencia));
            Console.WriteLine("");

            ocorrencias.ForEach(ocorrencia =>
            {
                ocorrencia.tipoOcorrencia = _tiposOcorrencias.First(to => to.id == ocorrencia.idTipoOcorrencia);
            });

            return ocorrencias;
        }

        [HttpGet("{placaVeiculo}", Name = "GetOcorrencia")]
        public IActionResult GetByDados(string placaVeiculo, [FromQuery] DateTime data, [FromQuery] TimeSpan hora)
        {
            Console.WriteLine("");
            Console.WriteLine("placa: " + placaVeiculo + ", data: " + data.ToShortDateString() + ", hora: " + hora);
            Console.WriteLine("");

            var item = _context.ocorrencia.FirstOrDefault(t => (t.placaVeiculo == placaVeiculo) && (t.data == data) && (t.hora.Equals(hora)));

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

            _context.ocorrencia.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetOcorrencia", new { placaVeiculo = item.placaVeiculo, data = item.data, hora = item.hora}, item);
        }

        [HttpPut("{placaVeiculo}")]
        public IActionResult Update(string placaVeiculo, [FromQuery] DateTime data, [FromQuery] TimeSpan hora, [FromBody] Ocorrencia item)
        {
            if (item == null || item.placaVeiculo != placaVeiculo || item.data != data || !(item.hora.Equals(hora)))
            {
                return BadRequest();
            }

            var todo = _context.ocorrencia.FirstOrDefault(t => (t.placaVeiculo == placaVeiculo) && (t.data == data) && (t.hora.Equals(hora)));
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

        [HttpDelete("{placaVeiculo}")]
        public IActionResult Delete(string placaVeiculo, [FromQuery] DateTime data, [FromQuery] TimeSpan hora)
        {
            var todo = _context.ocorrencia.FirstOrDefault(t => (t.placaVeiculo == placaVeiculo) && (t.data == data) && (t.hora.Equals(hora)));
            if (todo == null)
            {
                return NotFound();
            }

            _context.ocorrencia.Remove(todo);
            _context.SaveChanges();

            return new NoContentResult();
        }
    }
}
