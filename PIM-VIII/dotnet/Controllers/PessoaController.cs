using System;
using Microsoft.AspNetCore.Mvc;
using trabalho.Models;

namespace trabalho.Controllers
{
  public class PessoaController : Controller
  {
    public IActionResult Insira()
    {
      return View();
    }
    public IActionResult Consulte() {
      return View();
    }
    public IActionResult Altere(int id) {
      if(id > 0) {
        PessoaDAO pessoaDAO = new PessoaDAO();

        Pessoa p = pessoaDAO.consulte(id);
        if(p != null) {
          return View(p);
        } else {
          View();
        }
      }
      return View("AltereSemId");
    }
    public IActionResult Exclua() {
      return View();
    }
  }
}

