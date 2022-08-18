using IngressoMVC.Models.ViewModels.RequestDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzariaMVC.Data;
using PizzariaMVC.Models;
using System.Linq;

namespace IngressoMVC.Controllers
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
        public IActionResult Criar(PostPizzaDTO pizzaDto)
        {
            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View();
            }

            Pizza pizza = new Pizza
                (
                    
                );

            _context.Add(pizza);
            _context.SaveChanges();

            foreach (var saborId in pizzaDto.SaboresId)
            {
                var novoSabor = new PizzasSabores(pizza.Id, saborId);
                _context.PizzasSabores.Add(novoSabor);
                _context.SaveChanges();
            }

            foreach (var atorId in filmeDto.AtoresId)
            {
                var novoAtor = new AtorFilme(atorId, filme.Id);
                _context.AtoresFilmes.Add(novoAtor);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Filmes
                .Include(x => x.AtoresFilmes).ThenInclude(x => x.Ator)
                .Include(x => x.FilmesCategorias).ThenInclude(x => x.Categoria)
                .FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            var response = new PostFilmeDTO()
            {
                Titulo = result.Titulo,
                Descricao = result.Descricao,
                Preco = result.Preco,
                ImagemURL = result.ImagemURL,
                DataLancamento = result.DataLancamento,
                DataEncerramento = result.DataEncerramento,
                CinemaId = result.CinemaId,
                ProdutorId = result.ProdutorId,
                AtoresId = result.AtoresFilmes.Select(x => x.AtorId).ToList(),
                CategoriasId = result.FilmesCategorias.Select(x => x.CategoriaId).ToList()
            };

            DadosDropdown();
            return View(response);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDto)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
            {
                DadosDropdown();
                return View(result);
            }

            result.AlterarDados
                (
                filmeDto.Titulo,
                filmeDto.Descricao,
                filmeDto.Preco,
                filmeDto.ImagemURL,
                filmeDto.ProdutorId,
                filmeDto.CinemaId,
                filmeDto.DataEncerramento,
                filmeDto.DataEncerramento
                );

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Detalhes), result);
        }

        public IActionResult Deletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Filmes
                .Include(p => p.Produtor)
                .Include(c => c.Cinema)
                .Include(fc => fc.FilmesCategorias).ThenInclude(c => c.Categoria)
                .Include(af => af.AtoresFilmes).ThenInclude(a => a.Ator)
                .FirstOrDefault(f => f.Id == id);

            return View(result);
        }

        public void DadosDropdown()
        {
            var resp = new PostFilmeDropdownDTO()
            {
                Atores = _context.Atores.OrderBy(x => x.Nome).ToList(),
                Categorias = _context.Categorias.OrderBy(x => x.Nome).ToList(),
                Cinemas = _context.Cinemas.OrderBy(x => x.Nome).ToList(),
                Produtores = _context.Produtores.OrderBy(x => x.Nome).ToList()
            };

            ViewBag.Atores = new SelectList(resp.Atores, "Id", "Nome");
            ViewBag.Categorias = new SelectList(resp.Categorias, "Id", "Nome");
            ViewBag.Cinemas = new SelectList(resp.Cinemas, "Id", "Nome");
            ViewBag.Produtores = new SelectList(resp.Produtores, "Id", "Nome");
        }

        public IActionResult Buscar(string filtroDeBsuca)
        {
            var result = _context.Filmes
                .Include(filme => filme.AtoresFilmes).ThenInclude(atorFilme => atorFilme.Ator)
                .ToList();

            /*
            Filmes
	            Onde
		            (Filme.Titulo.Contem("busca")) ou
		            (Filme.Descri.Contem("busca)) ou
		            (Filme.AtoresFilmes.Atores.Nome.Contem("busca")) =[SOLUÇÃO ATIVIDADE]=
            */

            if (!string.IsNullOrEmpty(filtroDeBsuca))
            {
                filtroDeBsuca = filtroDeBsuca.ToLower().Trim();

                var resultadoDaBusca = result
                    .Where(filme =>
                        filme.Titulo.ToLower().Contains(filtroDeBsuca) ||
                        filme.Descricao.ToLower().Contains(filtroDeBsuca) ||
                        filme.AtoresFilmes.Select(af => af.Ator.Nome.ToLower().Contains(filtroDeBsuca)).FirstOrDefault())
                    .OrderBy(x => x.Titulo)
                    .ToList();

                return View(nameof(Index), resultadoDaBusca);
            }

            return View(nameof(Index), result);
        }
    }
}