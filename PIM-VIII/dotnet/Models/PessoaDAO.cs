using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models
{
  public class PessoaDAO : IGenericDAO<Pessoa>
  {
    private List<Pessoa> Pessoas = new List<Pessoa>();
    private SqliteConnection connection = Connection.getConnection();

    EnderecoDAO enderecoDAO = new EnderecoDAO();

    PessoaTelefoneDAO  pessoaTelefoneDAO = new PessoaTelefoneDAO();

    TelefoneDAO telefoneDAO = new TelefoneDAO();

    public Pessoa consulte(string cpf) {
       var command = connection.CreateCommand();

      command.CommandText = @"SELECT * from pessoa where cpf=$cpf";
      command.Parameters.AddWithValue("$cpf", cpf);

      var reader = command.ExecuteReader();

      if(reader.Read()) {
        var p_id = reader.GetInt16(0);
        var p_nome = reader.GetString(1);
        var p_cpf = reader.GetString(2);
        var p_endereco_id = reader.GetInt16(3);
          
        // conseguindo endereco
        var enderecoDAO = new EnderecoDAO();
        var p_endereco = enderecoDAO.consulte(p_endereco_id);

        // criando pessoa
        var pessoa = new Pessoa(p_id, p_nome, p_cpf, p_endereco);

        // conseguindo lista de telefones
        var pessoa_telefoneDAO = new PessoaTelefoneDAO();

        var pessoa_telefoneList = pessoa_telefoneDAO.consulte(p_id);


        var telefoneDAO = new TelefoneDAO();

        foreach(PessoaTelefone pessoaTelefone in pessoa_telefoneList) {
          var telefone = telefoneDAO.consulte(pessoaTelefone.id_telefone);
          pessoa.telefones.Add(telefone);
        }
        return pessoa;
      }
      return null;
    }
    public bool altere(Pessoa p) {
      // o telefone é a parte mais complicada por que outras pessoas
      // podem ter o mesmo telefone a solução é quando for criar um novo telefone 
      // verificar se já existe igual.
      
      // remove todos os telfones pertencente
      pessoaTelefoneDAO.exclua(p.id);

      foreach(Telefone t in p.telefones) {
        // cria novos telfones
        t.id = telefoneDAO.insira(t);
        // cria a associação
        pessoaTelefoneDAO.insira(new PessoaTelefone(p.id, t.id));
      }

      Pessoa pessoa = consulte(p.id);

      if(!pessoa.endereco.Equals(p.endereco)) {
        // Sempre cria um endereço novo
        p.endereco.id = enderecoDAO.insira(p.endereco);
      } else {
        p.endereco.id = pessoa.endereco.id;
      }

      var command = connection.CreateCommand();
      command.CommandText = @"UPDATE pessoa SET nome=$nome, cpf=$cpf, endereco=$endereco WHERE id=$id";
      command.Parameters.AddWithValue("$id", p.id);
      command.Parameters.AddWithValue("$nome", p.nome);
      command.Parameters.AddWithValue("$cpf", p.cpf);
      command.Parameters.AddWithValue("$endereco", p.endereco.id);


      return command.ExecuteNonQuery() == 0 ? false : true;
    }

    public Pessoa consulte(int id) {
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
        var p_endereco = enderecoDAO.consulte(p_endereco_id);

        // criando pessoa
        var pessoa = new Pessoa(p_id, p_nome, p_cpf, p_endereco);

        // conseguindo lista de telefones
        var pessoa_telefoneDAO = new PessoaTelefoneDAO();

        var pessoa_telefoneList = pessoa_telefoneDAO.consulte(p_id);


        var telefoneDAO = new TelefoneDAO();

        foreach(PessoaTelefone pessoaTelefone in pessoa_telefoneList) {
          var telefone = telefoneDAO.consulte(pessoaTelefone.id_telefone);
          pessoa.telefones.Add(telefone);
        }
        return pessoa;
      }

      return null;
    }

    public int insira(Pessoa p)
    {
      EnderecoDAO enderecoDAO = new EnderecoDAO();

      int endereco_id = enderecoDAO.insira(p.endereco);

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
         td.insira(t);
         var pessoa_telefone = new PessoaTelefone(p.id,t.id);
         pessoaTelefoneDAO.insira(pessoa_telefone);
       }
      }

      return id;
    }

    public bool exclua(int id)
    {
      PessoaTelefoneDAO pessoaTelefoneDAO = new PessoaTelefoneDAO();

      pessoaTelefoneDAO.exclua(id);

      var command = connection.CreateCommand();
      command.CommandText = @"DELETE FROM pessoa WHERE id=$id";

      command.Parameters.AddWithValue("$id", id);
      int affectedRows = command.ExecuteNonQuery();
      
      return affectedRows == 0 ? false : true;
    }

    public List<Pessoa> getAll()
    {
      var command = connection.CreateCommand();
      command.CommandText = @"SELECT id FROM pessoa;";
      var reader = command.ExecuteReader();

      while(reader.Read()) {
        var id = reader.GetInt32(0);
        var pessoa = consulte(id);
        Pessoas.Add(pessoa);
      }

      return Pessoas;
    }
  }
}

