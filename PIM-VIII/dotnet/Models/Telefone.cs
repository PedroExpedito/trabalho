namespace trabalho.Models {
  public class  Telefone{

    public int id;
    public int numero;
    public int DDD;
    public TelefoneTipo tipo;

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
