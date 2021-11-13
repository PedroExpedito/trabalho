using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models
{
  public class PessoaDAO : IGenericDAO<Pessoa>
  {
    private List<Pessoa> Pessoas = new List<Pessoa>();
    private SqliteConnection connection = Connection.getConnection();

    public bool update(Pessoa p) {
      return false;
    }
    public Pessoa get(int id) {
      return null;
    }
    public int create(Pessoa p)
    {

      EnderecoDAO enderecoDAO = new EnderecoDAO();

      int endereco_id = enderecoDAO.create(p.endereco);

      var command = connection.CreateCommand();
      command.CommandText = @"
        INSERT INTO pessoa ( nome, cpf, endereco) VALUES ( $nome, $cpf, $endereco); SELECT last_insert_rowid()
        ";
      command.Parameters.AddWithValue("$nome", p.nome);
      command.Parameters.AddWithValue("$cpf", p.cpf);
      command.Parameters.AddWithValue("$endereco", endereco_id);

      var telefones = p.telefones;

      TelefoneDAO td = new TelefoneDAO(); 

      if( telefones != null) {
      foreach(Telefone t in telefones) {
         td.create(t);
       }
      }

      int id = Convert.ToInt16(command.ExecuteScalar());

      return id;
    }

    public bool remove(int id)
    {
      var command = connection.CreateCommand();
      command.CommandText = @"DELETE FROM pessoa WHERE id=$id";

      command.Parameters.AddWithValue("$id", id);
      int affectedRows = command.ExecuteNonQuery();
      
      return affectedRows == 0 ? false : true;
    }

    public List<Pessoa> getAll()
    {
      var command = connection.CreateCommand();

      command.CommandText =
        @"
        SELECT * FROM PESSOA;
      ";
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var id = reader.GetInt16(0);
          var nome = reader.GetString(1);
          var cpf = reader.GetString(2);
          Pessoas.Add(new Pessoa(id, nome, cpf, null, null));
        }
      }
      return Pessoas;
    }
  }
}

