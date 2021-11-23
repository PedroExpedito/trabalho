using System.Collections.Generic;

namespace trabalho.Models
{
    public interface IGenericDAO<D> {
    public D consulte(int id);

    public List<D> getAll(); 

    public bool exclua(int id);

    public bool altere(D entity); 

    public int insira(D entity); 
}
}

