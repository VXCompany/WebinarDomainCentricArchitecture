using System;
using Domain.Model.Orders;
using Domain.Repositories;
using Domain.UseCases;

namespace ApplicationServices.UseCases
{
    public class OrderMetKortingUsecase : IOrderMetKortingUsecase
    {
        private readonly IKlantRepository _klantRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderMetKortingUsecase(
            IKlantRepository klantRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork)
        {
            _klantRepository = klantRepository ?? throw new ArgumentNullException(nameof(klantRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void PlaatsOrder(string klantIdentificatie, string productIdentificatie, int aantal)
        {
            var klant = _klantRepository.GetByKlantIdentificatie(klantIdentificatie);
            var product = _productRepository.GetByProductIdentificatie(productIdentificatie);

            var order = new Order(klant, product);

            order.Plaats(aantal);

            _orderRepository.PlaatsOrder(order);

            _unitOfWork.Commit();
        }
    }
}
