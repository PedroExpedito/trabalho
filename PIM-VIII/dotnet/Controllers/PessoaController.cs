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

    PessoaDAO pessoaDAO = new PessoaDAO();

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

      pessoaDAO.create(p);
      
      return "Sucesso";
    }


  }
}

