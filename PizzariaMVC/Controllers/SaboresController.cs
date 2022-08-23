using PizzariaMVC.Data;
using PizzariaMVC.Models;
using PizzariaMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaMVC.Controllers
{
    public class SaboresController : Controller
    {
        private PizzariaDbContext _context;

        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Sabores);
        }

        public IActionResult Detalhes(int id)
        {
            var resultado = _context.Sabores
                .Include(ps => ps.PizzasSabores)
                .ThenInclude(p => p.Pizza)
                .FirstOrDefault(sabor => sabor.Id == id);

            if (resultado == null)
                return View("NotFound");

            return View(resultado);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        public IActionResult Criar(PostSaborDTO saborDto)
        {
            if (!ModelState.IsValid)
                return View(saborDto);

            Sabor sabor = new Sabor(saborDto.Nome, saborDto.ImageURL);
            _context.Sabores.Add(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int? id)
        {
            if (id == null)
                return NotFound();

            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View();

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostSaborDTO saborDto)
        {
            var sabor = _context.Sabores.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
                return View(sabor);

            sabor.AtualizarDados(saborDto.Nome, saborDto.ImageURL);

            _context.Update(sabor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);

            if (result == null) return View();

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Sabores.FirstOrDefault(x => x.Id == id);
            _context.Sabores.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}