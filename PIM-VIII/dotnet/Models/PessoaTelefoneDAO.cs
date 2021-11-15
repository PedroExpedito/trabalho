using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models {
  public class PessoaTelefoneDAO {

    public List<TelefoneTipo> telefoneTipos  = new List<TelefoneTipo>();
    private SqliteConnection connection = Connection.getConnection();



    // retorna uma lista com todos os telefones de uma pessoa
    public List<PessoaTelefone> get(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"select * from pessoa_telefone where id_pessoa=$id";
      command.Parameters.AddWithValue("$id", id);

      var reader =  command.ExecuteReader();

      List<PessoaTelefone> pessoaTelefones = new List<PessoaTelefone>();
      while (reader.Read()) {
        var id_pessoa = reader.GetInt16(0);
        var id_telefone = reader.GetInt16(1);
        var pessoaTelefone = new PessoaTelefone(id_pessoa, id_telefone);
        pessoaTelefones.Add(pessoaTelefone);
      }
      return pessoaTelefones;
    }

    public List<PessoaTelefone> getAll(){
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
      return null;
    }

    public bool remove(int id){
      var command = connection.CreateCommand();
      command.CommandText =  @"delete from telefone_tipo where id=$id";
      command.Parameters.AddWithValue("$id", id);
      return command.ExecuteNonQuery() == 0 ? false : true;
    }

    public bool update(PessoaTelefone entity) {
      var command = connection.CreateCommand();
      return false; 
    }

    public int create(PessoaTelefone entity){
      int pessoa_id =  entity.id_pessoa;
      int telefone_id =  entity.id_telefone;

      var command = connection.CreateCommand();

      command.CommandText =  @"insert into pessoa_telefone (id_pessoa, id_telefone)VALUES
        ($pessoa_id, $telefone_id); SELECT last_insert_rowid()";

      command.Parameters.AddWithValue("$pessoa_id", pessoa_id );
      command.Parameters.AddWithValue("$telefone_id", telefone_id);

      int id = Convert.ToInt16(command.ExecuteScalar());
      return id;
    }

  }
}

