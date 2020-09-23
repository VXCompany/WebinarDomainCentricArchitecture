using System.Collections.Generic;
using Domain.Model.Producten;

namespace Domain.UseCases
{
    public interface IToonProductenUseCase
    {
        IEnumerable<Product> ToonProducten();
    }
}
