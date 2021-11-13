using System.Collections.Generic;

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

      Pessoa() {
        telefones = new List<Telefone>();
      }
      public Pessoa(string nome, string cpf, Endereco endereco,
          List<Telefone> telefones) : base() {
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefones = telefones;
      }
      public Pessoa(int id, string nome, string cpf, Endereco endereco,
          List<Telefone> telefones) : base() {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefones = telefones;
      }
    }
}
