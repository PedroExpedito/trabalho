using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using trabalho.Models;

namespace trabalho
{
    public class Program
  {
    public static void Main(string[] args)
    {

     // var enderecoDAO = new EnderecoDAO();
     //
     // var enderecos = enderecoDAO.getAll();
     //
     var endereco1 = new Endereco("HASDAS", 1, "863782", "centro", "cafesal", "parana");
     // enderecoDAO.remove(1);
     // enderecoDAO.create(endereco1);
     //
     // Console.WriteLine(enderecoDAO.get(8).ToString());
     // Console.WriteLine("CHEGOU");
     // foreach( var e in enderecos) {
     //   Console.WriteLine(e);
     // }
     //
     PessoaDAO pessoaDAO = new PessoaDAO();

     // var telefoneTipo = new TelefoneTipo(2, "comercial");
     // var telefone = new Telefone(3,8374323, 43, telefoneTipo);
     //
     // List<Telefone> telefones = new List<Telefone>();
     // telefones.Add(telefone);
     //
     // var pessoa = new Pessoa("Marcos","293838293", endereco1, telefones); 
     var pessoa = pessoaDAO.get(4);

     Console.WriteLine(pessoa.ToString());

     // CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
          {
          webBuilder.UseStartup<Startup>();
          });
  }
}
