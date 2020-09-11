using Domain.Model.Produkten;

namespace Domain.Repositories
{
    public interface IProduktRepository
    {
        Produkt GetByProduktIdentificatie(string produktIdentificatie);
    }
}
