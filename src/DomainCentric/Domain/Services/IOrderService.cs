namespace Domain.Services
{
    public interface IOrderService
    {
        void PlaatsOrder(string klantIdentificatie, string produktIdentificatie, int aantal);
    }
}
