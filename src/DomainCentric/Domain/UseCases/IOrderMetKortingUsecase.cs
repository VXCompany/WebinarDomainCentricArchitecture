namespace Domain.UseCases
{
    public interface IOrderMetKortingUsecase
    {
        void PlaatsOrder(string klantIdentificatie, string productIdentificatie, int aantal);
    }
}
