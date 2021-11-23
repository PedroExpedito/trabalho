using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trabalho.Models;

namespace trabalho.Controllers
{
    [Route("api/pessoa")]

  [ApiController]
  public class PessoaController : Controller
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


    public IActionResult criarPessoa([FromBody] Pessoa pessoa) {
      if(pessoaDAO.insira(pessoa) > 0) {;
        return Json(pessoa);
      } else {
        Response.StatusCode = 404;
        return Json(new { Message = "user not created" });
      }
    }


    [HttpPost]
    public String postComplex(IFormCollection collection) {
      string nome = collection["nome"].ToString();
      string cpf = collection["cpf"].ToString();
      string logradouro = collection["logradouro"].ToString();
      int numero = Convert.ToInt32(collection["numero"].ToString());
      string cep = collection["cep"].ToString();
      string bairro = collection["bairro"].ToString();
      string cidade = collection["cidade"].ToString();
      string estado = collection["estado"].ToString();
      int t_numero = Convert.ToInt32(collection["t_numero"].ToString());
      int DDD = Convert.ToInt32(collection["ddd"].ToString());
      string tipo = collection["tipo"].ToString();

      TelefoneTipo tTipo = new TelefoneTipo(tipo);

      Endereco e = new Endereco(logradouro, numero, cep, bairro, cidade, estado);

      Telefone t = new Telefone(numero,DDD,tTipo);


      Pessoa p = new Pessoa(nome, cpf, e);
      p.telefones.Add(t);

      pessoaDAO.insira(p);
      
      return "secusso";
    }


  }
}

