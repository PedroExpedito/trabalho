namespace trabalho.Models {
  public class  Telefone{

    private int id;
    private int numero;
    private int DDD;
    private TelefoneTipo tipo;

    public Telefone(int numero, int DDD, TelefoneTipo tipo) {
      this.numero = numero;
      this.DDD = DDD;
      this.tipo = tipo;
    }

  }

}
