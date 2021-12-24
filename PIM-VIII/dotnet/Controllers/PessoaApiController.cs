using Microsoft.AspNetCore.Mvc;
using trabalho.Models;

namespace trabalho.Controllers
{
    [Route("api/pessoa")]

  [ApiController]
  public class PessoaApiController : Controller
  {

    [HttpGet("{id}")]
    public IActionResult getPessoa([FromRoute] int id) {
     Pessoa pessoa = pessoaDAO.consulte(id);
     if(pessoa == null) {
       Response.StatusCode = 404;
       return Json(new { Message = "User not found" });
     }
     return Json(pessoa); 
    }

    [HttpDelete("{id}")]
    public IActionResult deletePessoa([FromRoute] int id) {
      if(!pessoaDAO.exclua(id)) {
        Response.StatusCode = 404;
        return Json(new { Message = "User not found" });
      }
      return Json(new { Message = "User deleted" });
    }

    [HttpPut]
    public IActionResult updatePessoa([FromBody] Pessoa pessoa) {
      if(!pessoaDAO.altere(pessoa)) {
        Response.StatusCode = 404;
        return Json(new { Message = "User not found" });
      }
      return Json(new { Message = "User Updated" });
    }


    PessoaDAO pessoaDAO = new PessoaDAO();


    [HttpPost]
    public IActionResult criarPessoa([FromBody] Pessoa pessoa) {
      if(pessoaDAO.insira(pessoa) > 0) {;
        return Json(pessoa);
      } else {
        Response.StatusCode = 404;
        return Json(new { Message = "user not created" });
      }
    }
  }
}

