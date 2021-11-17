using System.Collections.Generic;
using System.Text;

namespace trabalho.Models
{
  public class Pessoa
  {
      public int id { get; set; }
      public string nome { get; set; }
      public string cpf { get; set; }
      public Endereco endereco { get; set;}
      public List<Telefone> telefones { get; set; }
      //public Endereco endereco { get; set; }

      public Pessoa(string nome, string cpf, Endereco endereco,
          List<Telefone> telefones) {
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefones = telefones;
      }
      public Pessoa(int id, string nome, string cpf, Endereco endereco,
          List<Telefone> telefones) {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefones = telefones;
      }
      public Pessoa(int id, string nome, string cpf, Endereco endereco) {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefones = new List<Telefone>();
      }

      
      public override string ToString() {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Id: {id}, Nome: {nome}, Cpf: {cpf}, \nEndereco: ");
        sb.Append(endereco.ToString());
        sb.Append("Telefones: \n");

        foreach( Telefone e in telefones) {
          sb.Append(e.ToString() + "\n");
        }

        return sb.ToString();
      }

    }
}
