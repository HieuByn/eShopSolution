using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequestDto request);
        Task<int> Update(ProductEditRequestDto request);
        Task<int> Delete(int productId);
        Task<List<ProductViewModelDto>> GetAll();
        Task<PagedViewModel<ProductViewModelDto>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}
