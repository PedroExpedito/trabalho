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

      // TelefoneTipoDAO telefoneTipoDAO = new TelefoneTipoDAO();
      //
      // var telefoneTipo = new TelefoneTipo("fixo");
      // long result = telefoneTipoDAO.exist(telefoneTipo);
      //
      // Console.WriteLine(result);

     CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
          {
          webBuilder.UseStartup<Startup>();
          });
  }
}
