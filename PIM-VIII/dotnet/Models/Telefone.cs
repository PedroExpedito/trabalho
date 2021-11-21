namespace trabalho.Models {
  public class  Telefone{

<<<<<<< HEAD
    public int id {get; set; }
    public int numero {get; set; }
    public int DDD {get; set; }
    public TelefoneTipo tipo {get; set; }
=======
    public int id{get; set;}
    public int numero{get; set;}
    public int DDD{get; set;}
    public TelefoneTipo tipo{get; set;}
>>>>>>> old

    public Telefone() {}

    public Telefone(int numero, int DDD, TelefoneTipo tipo) {
      this.numero = numero;
      this.DDD = DDD;
      this.tipo = tipo;
    }
    public Telefone(int id, int numero, int DDD, TelefoneTipo tipo) {
      this.id = id;
      this.numero = numero;
      this.DDD = DDD;
      this.tipo = tipo;
    }

    public override string ToString() {
      return $"Id: {id}, Numero: {numero}, DDD: {DDD}, Tipo: {tipo}";
    }

  }

}
