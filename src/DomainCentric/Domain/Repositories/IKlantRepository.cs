using Domain.Model.Klanten;

namespace Domain.Repositories
{
    public interface IKlantRepository
    {
        Klant GetByKlantIdentificatie(string klantIdentificatie);
    }
}
