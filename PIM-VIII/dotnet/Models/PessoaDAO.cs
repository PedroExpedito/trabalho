using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models
{
    public class PessoaDAO : IGenericDAO<Pessoa>
    {
        private List<Pessoa> Pessoas = new List<Pessoa>();
        private SqliteConnection connection = Connection.getConnection();

        public void update(Pessoa p) {
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

            int id = Convert.ToInt16(command.ExecuteScalar());

            return id;
        }

        public void remove(int id)
        {
            try
            {
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM pessoa WHERE id=$id";

                command.Parameters.AddWithValue("$id", id);
                int affectedRows = command.ExecuteNonQuery();
                Console.WriteLine(affectedRows);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                Console.WriteLine("CHEGO");
            }

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

