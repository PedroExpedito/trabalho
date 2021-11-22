namespace trabalho.Models {
  public class PessoaTelefone {
    public int id_pessoa;
    public int id_telefone;


    public PessoaTelefone(int pessoa_id,int telefone_id) {
      this.id_pessoa = pessoa_id;
      this.id_telefone = telefone_id;
    }
  }
}
