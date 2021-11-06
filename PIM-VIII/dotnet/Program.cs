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

     var enderecoDAO = new EnderecoDAO();

     var enderecos = enderecoDAO.getAll();

     // var endereco1 = new Endereco(0,"logradouro", 1, "863782", "centro", "cafesal", "parana");
     // enderecoDAO.remove(1);
     // enderecoDAO.create(endereco1);

     Console.WriteLine(enderecoDAO.get(8).ToString());
     // Console.WriteLine("CHEGOU");
     // foreach( var e in enderecos) {
     //   Console.WriteLine(e);
     // }

//      PessoaDAO pessoaDAO = new PessoaDAO();


      // var pessoa = new Pessoa(20, "Ana","293838293"); 
      // pessoaDAO.addPessoa(pessoa);
      // for ( int i = 10; i <= 17; i++) {
      //   pessoaDAO.deletePessoaById(i);
      // }
      // pessoaDAO.deletePessoaById(7);
      //
      // var pessoas = pessoaDAO.getPessoas();
      //
      // foreach( var p in pessoas) {
      //   Console.WriteLine(p.nome);
      // }
//      CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
          {
          webBuilder.UseStartup<Startup>();
          });
  }
}
