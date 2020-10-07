using System.Collections.Generic;
using Domain.Model.Producten;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetByProductIdentificatie(string productIdentificatie);
        IEnumerable<Product> GetAll();
    }
}
