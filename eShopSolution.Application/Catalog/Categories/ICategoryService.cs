using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);
        Task<CategoryVm> GetById(string languageId, int id);
        Task<PagedResultDto<CategoryVm>> GetAllPaging(GetManageProductPagingRequest request);
    }
}
