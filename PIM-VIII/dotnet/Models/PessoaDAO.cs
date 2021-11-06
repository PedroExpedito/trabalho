using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace trabalho.Models
{
    public class PessoaDAO
    {
        private List<Pessoa> Pessoas = new List<Pessoa>();
        private SqliteConnection connection = Connection.getConnection();


        public PessoaDAO()
        {
            connection.Open();
        }
        ~PessoaDAO()
        {
            connection.Close();
        }

        public void addPessoa(Pessoa p)
        {
            var command = connection.CreateCommand();
            command.CommandText = @"
        INSERT INTO pessoa ( nome, cpf) VALUES ( $nome, $cpf)
        ";
            command.Parameters.AddWithValue("$nome", p.nome);
            command.Parameters.AddWithValue("$cpf", p.cpf);

            command.ExecuteNonQuery();
        }

        public void deletePessoaById(int id)
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

        public List<Pessoa> getPessoas()
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

