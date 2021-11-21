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
      var command = connection.CreateCommand();

      EnderecoDAO enderecoDAO = new EnderecoDAO();
      enderecoDAO.update(p.endereco);

      // TODO falta telefone
      // por ultimo
      command.CommandText = @"UPDATE pessoa SET nome=$nome, cpf=$cpf, endereco=$endereco where id=$id";

      command.Parameters.AddWithValue("$id", p.id);
      command.Parameters.AddWithValue("$nome", p.nome);
      command.Parameters.AddWithValue("$cpf", p.cpf);
      command.Parameters.AddWithValue("$endereco", p.endereco.id);

      return command.ExecuteNonQuery() == 0 ? false : true;
    }
    public Pessoa get(int id) {
      var command = connection.CreateCommand();

      command.CommandText = @"SELECT * from pessoa where id=$id";
      command.Parameters.AddWithValue("$id", id);

      var reader = command.ExecuteReader();

      if(reader.Read()) {
        var p_id = reader.GetInt16(0);
        var p_nome = reader.GetString(1);
        var p_cpf = reader.GetString(2);
        var p_endereco_id = reader.GetInt16(3);
          
        // conseguindo endereco
        var enderecoDAO = new EnderecoDAO();
        var p_endereco = enderecoDAO.get(p_endereco_id);

        // criando pessoa
        var pessoa = new Pessoa(p_id, p_nome, p_cpf, p_endereco);

        // conseguindo lista de telefones
        var pessoa_telefoneDAO = new PessoaTelefoneDAO();

        var pessoa_telefoneList = pessoa_telefoneDAO.get(p_id);


        var telefoneDAO = new TelefoneDAO();

        foreach(PessoaTelefone pessoaTelefone in pessoa_telefoneList) {
          var telefone = telefoneDAO.get(pessoaTelefone.id_telefone);
          pessoa.telefones.Add(telefone);
        }
        return pessoa;
      }

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


      int id = Convert.ToInt16(command.ExecuteScalar());

      p.id = id;

      if( telefones != null) {
      var pessoaTelefoneDAO = new PessoaTelefoneDAO();

      foreach(Telefone t in telefones) {
         t.id = td.create(t);
         var pessoa_telefone = new PessoaTelefone(p.id,t.id);
         pessoaTelefoneDAO.create(pessoa_telefone);
     }

      }

      return id;
    }

    public bool remove(int id)
    {
<<<<<<< HEAD

=======
>>>>>>> old
      PessoaTelefoneDAO pessoaTelefoneDAO = new PessoaTelefoneDAO();

      pessoaTelefoneDAO.remove(id);

<<<<<<< HEAD

=======
>>>>>>> old
      var command = connection.CreateCommand();
      command.CommandText = @"DELETE FROM pessoa WHERE id=$id";

      command.Parameters.AddWithValue("$id", id);
      int affectedRows = command.ExecuteNonQuery();
      
      return affectedRows == 0 ? false : true;
    }
    public List<Pessoa> getAll() {
      return null;
    }
  }
}

