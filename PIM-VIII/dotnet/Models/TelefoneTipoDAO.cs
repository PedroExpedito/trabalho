using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models {
  public class TelefoneTipoDAO : IGenericDAO<TelefoneTipo>{

    public List<TelefoneTipo> telefoneTipos  = new List<TelefoneTipo>();
    private SqliteConnection connection = Connection.getConnection();



    public TelefoneTipo get(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"select * from telefone_tipo where id=$id";
      command.Parameters.AddWithValue("$id", id);

      var reader = command.ExecuteReader();
      if(reader.Read()) {
        var id_telefone_tipo = reader.GetInt16(0);
        var tipo = reader.GetString(1);

        var telefoneTipo = new TelefoneTipo(id_telefone_tipo, tipo);
        return telefoneTipo;
      }
      return null;
    }

    public List<TelefoneTipo> getAll(){
      var command = connection.CreateCommand();

      command.CommandText = @"SELECT * FROM telefone_tipo;";
      using ( var reader = command.ExecuteReader()) {
        while (reader.Read()) {
          var id = reader.GetInt16(0);
          var tipo = reader.GetString(1);
          var telefoneTipo = new TelefoneTipo(id, tipo);
          telefoneTipos.Add(telefoneTipo);
        }
      }
      return telefoneTipos;
    }

    public bool remove(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"delete from telefone_tipo where id=$id";
      command.Parameters.AddWithValue("$id", id);
      return command.ExecuteNonQuery() == 0 ? false : true;
    }

    public bool update(TelefoneTipo  entity) {
      var id = entity.id;
      var tipo = entity.tipo;
      var command = connection.CreateCommand();
      command.CommandText =  @"UPDATE telefone_tipo SET tipo=$tipo where id=$id";
      command.Parameters.AddWithValue("$id", id);
      command.Parameters.AddWithValue("$tipo", tipo);
      return command.ExecuteNonQuery() == 0 ? false : true;
    }

    public int create(TelefoneTipo entity){
      try{
        int _id = exist(entity);
        return _id;
      } catch(Exception e) {
        var tipo = entity.tipo;
        var command = connection.CreateCommand();
        command.CommandText =  @"insert into telefone_tipo (tipo) VALUES ($tipo); SELECT last_insert_rowid()";
        command.Parameters.AddWithValue("$tipo", tipo);
        int id = Convert.ToInt16(command.ExecuteScalar());
        return id;
        throw e;
      }
    }
    public int exist(TelefoneTipo tp) {
      var command = connection.CreateCommand();
      command.CommandText = @"select * from telefone_tipo where tipo=$tipo;";
      command.Parameters.AddWithValue("$tipo", tp.tipo);

      int id = 0;
      try{
        id = Convert.ToInt16(command.ExecuteScalar());
        return id;
      } catch(Exception e) {
        throw e;
      }
    }

  }
}
