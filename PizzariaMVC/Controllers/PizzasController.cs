using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pizzaria.Models.ViewModels.RequestDTO;
using PizzariaMVC.Data;
using PizzariaMVC.Models;
using PizzariaMVC.Models.ViewModels.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Controllers
{
    public class PizzasController : Controller
    {
        private PizzariaDbContext _context;

        public PizzasController(PizzariaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Pizzas);

        public IActionResult Criar()
        {
            DadosDropdown();

            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostPizzaDTO pizzaDTO)
        {
            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View();
            }

            Pizza pizza = new Pizza
                (
                    pizzaDTO.Nome,
                    pizzaDTO.FotoURL,
                    pizzaDTO.Preco,
                    pizzaDTO.TamanhoId
                );

            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saborId in pizzaDTO.SaboresId)
            {
                var novoSabor = new PizzaSabor(pizza.Id, saborId);
                _context.PizzasSabores.Add(novoSabor);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Pizzas
                .Include(x => x.PizzasSabores).ThenInclude(x => x.Sabor)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostPizzaDTO()
            {
                Nome = result.Nome,
                FotoURL = result.ImageURL,
                Preco = result.Preco,
                SaboresId = result.PizzasSabores.Select(x => x.SaborId).ToList(),

            };

            DadosDropdown();
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostPizzaDTO pizzaDto)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View(result);
            }

            result.AtualizarDados
                (
                    pizzaDto.FotoURL,
                    pizzaDto.Preco,
                    pizzaDto.Nome,
                    pizzaDto.TamanhoId
                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), result);
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Pizzas.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Pizzas
                .Include(t => t.Tamanho)
                .Include(ps => ps.PizzasSabores).ThenInclude(s => s.Sabor)
                .FirstOrDefault(x => x.Id == id);

            return View(result);
        }

        #region DadosDropdown
        public void DadosDropdown()
        {
            var resp = new PostPizzaDropdown()
            {
                Sabores = _context.Sabores.OrderBy(x => x.Nome).ToList(),
                Tamanhos = _context.Tamanhos.OrderBy(x => x.Nome).ToList()
            };

            ViewBag.Sabores = new SelectList(resp.Sabores, "Id", "Nome");
            ViewBag.Tamanhos = new SelectList(resp.Tamanhos, "Id", "Nome");
        }
        #endregion
    }
}