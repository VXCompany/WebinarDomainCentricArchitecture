using System;
using Domain.Model.Orders;
using Domain.Repositories;
using Domain.Services;

namespace ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IKlantRepository _klantRepository;
        private readonly IProduktRepository _produktRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            IKlantRepository klantRepository,
            IProduktRepository produktRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _klantRepository = klantRepository ?? throw new ArgumentNullException(nameof(klantRepository));
            _produktRepository = produktRepository ?? throw new ArgumentNullException(nameof(produktRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void PlaatsOrder(string klantIdentificatie, string produktIdentificatie, int aantal)
        {
            var klant = _klantRepository.GetByKlantIdentificatie(klantIdentificatie);
            var produkt = _produktRepository.GetByProduktIdentificatie(produktIdentificatie);

            var order = new Order(klant, produkt);

            order.Plaats(aantal);

            _orderRepository.PlaatsOrder(order);

            _unitOfWork.Commit();
        }
    }
}
