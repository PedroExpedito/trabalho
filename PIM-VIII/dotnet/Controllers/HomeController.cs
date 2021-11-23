using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trabalho.Models;

namespace trabalho.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Pessoas()
        {
            return View();
        }
        public IActionResult Deletar() {
            return View();
        }
        // [HttpGet("{id}")]
        public IActionResult Editar([FromRoute] int id) {
          PessoaDAO pessoaDAO = new PessoaDAO();
          Pessoa pessoa = pessoaDAO.get(id);
          if(pessoa == null) {
            // TODO ARRUMAR ISSO
            return View("Privacy");
          }
          return View(pessoa);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public HttpResponseMessage postComplex() {
          Console.WriteLine("CHEGOU HTTP");
          return null;
        }
    }
}
