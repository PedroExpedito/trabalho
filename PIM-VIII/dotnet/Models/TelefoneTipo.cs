namespace trabalho.Models {
  public class  TelefoneTipo{

    public int id {get; set;}
    public string tipo {get; set;}

    public TelefoneTipo() {}

    public TelefoneTipo(string tipo) {
      this.tipo = tipo;
    }
    public TelefoneTipo(int id, string tipo) {
      this.id = id;
      this.tipo = tipo;
    }

    public override string ToString() {
      return tipo;
    }

  }
  

}

