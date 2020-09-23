namespace Domain.Services
{
    public interface IOrderMetKortingUsecase
    {
        void PlaatsOrder(string klantIdentificatie, string productIdentificatie, int aantal);
    }
}
