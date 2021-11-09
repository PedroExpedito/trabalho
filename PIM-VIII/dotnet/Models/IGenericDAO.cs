using System.Collections.Generic;

namespace trabalho.Models
{
    public interface IGenericDAO<D> {
    public D get(int id);

    public List<D> getAll(); 

    public void remove(int id);

    public void update(D entity); 

    public int create(D entity); 
}
}

