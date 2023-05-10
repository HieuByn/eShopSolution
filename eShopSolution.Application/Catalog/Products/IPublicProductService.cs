﻿using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResultDto<ProductViewModelDto>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
        //Task<List<ProductViewModelDto>> GetAll(string languageId);

    }
}
