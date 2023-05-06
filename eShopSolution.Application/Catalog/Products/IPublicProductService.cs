using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog
{
    public interface IPublicProductService
    {
        PagedViewModel<ProductViewModelDto> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize);

    }
}
