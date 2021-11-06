using System.Collections.Generic;

namespace trabalho.Models
{
    public interface IGenericDAO<D> {
    public D get(int id);// as Id use Long instead of Integer, Ids can be very large numbers, Int can be not enough

    public List<D> getAll(); //for retrieving more than one element 

    public void remove(int id);

    public void update(D entity); // remember that updated record should have already id inside, you can add assert inside

    public void create(D entity); // assert that id is null
}
}

