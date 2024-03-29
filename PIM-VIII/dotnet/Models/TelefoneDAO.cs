using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models
{
  public class TelefoneDAO: IGenericDAO<Telefone> {

    private SqliteConnection connection = Connection.getConnection();
    private List<Telefone> telefones = new List<Telefone>();

    public Telefone consulte(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"select * from telefone where id=$id";
      command.Parameters.AddWithValue("$id", id);

      var reader = command.ExecuteReader();
      if(reader.Read()) {
        var id_telefone = reader.GetInt16(0);
        var numero = reader.GetInt32(1);
        var DDD = reader.GetInt16(2);
        var tipo_int = reader.GetInt16(3);

        var telefoneTipoDAO = new TelefoneTipoDAO();

        var telefone_tipo = telefoneTipoDAO.consulte(tipo_int);

        var telefone = new Telefone(id_telefone, numero, DDD, telefone_tipo); 

        return telefone;
      }
      return null;
    }

    public List<Telefone> getAll(){
      var command = connection.CreateCommand();

      command.CommandText = @"SELECT * FROM telefone;";

      using ( var reader = command.ExecuteReader()) {
        while (reader.Read()) {
          var id_telefone = reader.GetInt16(0);
          var numero = reader.GetInt16(1);
          var DDD = reader.GetInt16(2);
          var tipo_int = reader.GetInt16(3);

          var telefoneTipoDAO = new TelefoneTipoDAO();

          var telefone_tipo = telefoneTipoDAO.consulte(tipo_int);

          var telefone = new Telefone(id_telefone, numero, DDD, telefone_tipo); 

          telefones.Add(telefone);

        }
      }
      return telefones;
    } 

    public bool exclua(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"delete from telefone where id=$id";
      command.Parameters.AddWithValue("$id", id);
      return command.ExecuteNonQuery() == 0 ? false : true;
    }

    public bool altere(Telefone entity){

      var id = entity.id;
      var numero = entity.numero;
      var DDD = entity.DDD;
      var tipo = entity.tipo.id;

      var command = connection.CreateCommand();
      command.CommandText =  @"UPDATE telefone SET numero=$numero, ddd=$ddd tipo=$tipo where id=$id";
      command.Parameters.AddWithValue("$id", id);
      command.Parameters.AddWithValue("$numero", numero);
      command.Parameters.AddWithValue("$ddd", DDD);
      command.Parameters.AddWithValue("$tipo", tipo);
      return command.ExecuteNonQuery() == 0 ? false : true;

    } 

    public int insira(Telefone entity){

      try{
         int _id = exist(entity);
         return _id;
      }catch(Exception e) {
        Console.WriteLine(e.Message);
      }

      var command = connection.CreateCommand();

      int numero = entity.numero;
      int DDD = entity.DDD;

      TelefoneTipoDAO TTD = new TelefoneTipoDAO();

      int tipo_id = TTD.insira(entity.tipo);
      entity.id = tipo_id;


      command.CommandText =  @"insert into telefone (numero, ddd, tipo) VALUES ($numero, $ddd, $tipo); SELECT last_insert_rowid()";
      command.Parameters.AddWithValue("$numero", numero);
      command.Parameters.AddWithValue("$ddd", DDD);
      command.Parameters.AddWithValue("$tipo", tipo_id);
      Console.WriteLine("tipo id: " + tipo_id);

      int id = Convert.ToInt32(command.ExecuteScalar());
      return id;



      }

      public  int exist(Telefone t) {
        var command = connection.CreateCommand();
        command.CommandText = @"select * from telefone numero=$numero, ddd=$ddd, tipo=$tipo;";
        command.Parameters.AddWithValue("$numero", t.numero);
        command.Parameters.AddWithValue("$ddd", t.DDD);
        command.Parameters.AddWithValue("$tipo", t.tipo.id);

        int id = 0;
        id = Convert.ToInt16(command.ExecuteScalar());
        return id;

    } 



  }
}
