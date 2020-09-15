namespace Domain.Services
{
    public interface IOrderMetKortingUsecase
    {
        void PlaatsOrder(string klantIdentificatie, string produktIdentificatie, int aantal);
    }
}
