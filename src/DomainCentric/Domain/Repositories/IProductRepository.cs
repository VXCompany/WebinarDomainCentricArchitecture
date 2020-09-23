using Domain.Model.Producten;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetByProductIdentificatie(string productIdentificatie);
    }
}
