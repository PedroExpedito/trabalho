using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace trabalho.Controllers
{
    [Route("api/pessoa")]
  [ApiController]
  public class PessoaController : Controller
  {
    [HttpPost]
    public String postComplex(IFormCollection collection) {
      string nome = collection["nome"].ToString();
      string cpf = collection["cpf"].ToString();
      string logradouro = collection["logradouro"].ToString();
      string numero = collection["numero"].ToString();
      string cep = collection["cep"].ToString();
      string bairro = collection["bairro"].ToString();
      string cidade = collection["cidade"].ToString();
      string estado = collection["estado"].ToString();
      string telefone = collection["telefone"].ToString();

      Console.WriteLine(nome);
      Console.WriteLine(cpf);
      Console.WriteLine(logradouro);
      Console.WriteLine(numero);
      Console.WriteLine(cep);
      Console.WriteLine(bairro);
      Console.WriteLine(cidade);
      Console.WriteLine(estado);
      Console.WriteLine(telefone);
      
      return nome;
    }


  }
}

