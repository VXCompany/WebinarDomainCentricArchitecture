using System.Collections.Generic;
using Domain.Model.Producten;
using Domain.Repositories;
using Domain.UseCases;

namespace ApplicationServices.UseCases
{
    public class ToonProductenUsecase : IToonProductenUseCase
    {
        private readonly IProductRepository _productRepository;

        public ToonProductenUsecase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> ToonProducten()
        {
            return _productRepository.GetAll();
        }
    }
}
