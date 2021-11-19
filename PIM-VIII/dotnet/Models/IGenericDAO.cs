
namespace trabalho.Models
{
    public interface IGenericDAO<D> {

    public D get(int id);

    public bool remove(int id);

    public bool update(D entity); 

    public int create(D entity); 
}
}

