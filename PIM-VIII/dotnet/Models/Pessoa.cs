namespace trabalho.Models
{
  public class Pessoa
  {
      public int id { get; set; }
      public string nome { get; set; }
      public string cpf { get; set; }
      public Endereco endereco { get; set;}
      public Telefone telefone { get; set; }
      //public Endereco endereco { get; set; }
      public Pessoa(string nome, string cpf, Endereco endereco,
          Telefone telefone) {
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefone = telefone;
      }
      public Pessoa(int id, string nome, string cpf, Endereco endereco,
          Telefone telefone) {
        this.id = id;
        this.nome = nome;
        this.cpf = cpf;
        this.endereco = endereco;
        this.telefone = telefone;
      }
    }
}
