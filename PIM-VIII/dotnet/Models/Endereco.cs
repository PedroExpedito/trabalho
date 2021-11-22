using System;

namespace trabalho.Models
{
  public class Endereco 
  {
    public int id {get; set;}
    public string logradouro{get; set;}
    public int numero{get; set;}
    public string cep { get; set;}
    public string bairro{get; set;}
    public string cidade{get; set;}
    public string estado{get; set;}

    public Endereco() {}

    public  Endereco(int id,  string logradouro, int numero,
        string cep, string bairro, string cidade, string estado) {
      this.id = id;
      this.logradouro = logradouro;
      this.numero = numero;
      this.cep = cep;
      this.bairro = bairro;
      this.cidade = cidade;
      this.estado = estado;

    }
    public  Endereco( string logradouro, int numero,
        string cep, string bairro, string cidade, string estado) {
      this.logradouro = logradouro;
      this.numero = numero;
      this.cep = cep;
      this.bairro = bairro;
      this.cidade = cidade;
      this.estado = estado;

    }

    public bool Equals(Endereco e) {
      if(!this.logradouro.Equals(e.logradouro)) { return false; }
      if(!this.numero.Equals(e.numero)) return false;
      if(!this.cep.Equals(e.cep)) return false;
      if(!this.bairro.Equals(e.bairro)) return false;
      if(!this.cidade.Equals(e.cidade)) return false;
      if(!this.estado.Equals(e.estado)) return false;
      Console.WriteLine(this.numero + " e " + e.numero);

      return true;
    }

    public override string ToString() {
      return $"id: {id}, logradouro: {logradouro}, numero: {numero}, cep: {cep} bairro: {bairro}, cidade: {cidade}, estado: {estado}\n";
    }
  }

}

