using Domain.Model.Orders;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        void PlaatsOrder(Order order);
    }
}
