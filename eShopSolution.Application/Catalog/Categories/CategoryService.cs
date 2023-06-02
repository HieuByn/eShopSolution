using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Catalog.Products;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbcontext _context;
        public CategoryService(EShopDbcontext context)
        {
            _context = context;
        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _context.Categories

                        join ct in _context.CategoryTranslations
                        on c.Id equals ct.CategoryId

                        where ct.LanguageId == languageId
                        select new { c, ct };

            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();

        }

        public async Task<PagedResultDto<CategoryVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from c in _context.Categories

                        join ct in _context.CategoryTranslations
                        on c.Id equals ct.CategoryId
                        into ctJoined
                        from ct in ctJoined.DefaultIfEmpty()
                        where ct.LanguageId == request.LanguageId
                        select new { c, ct };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new CategoryVm()
                            {
                                Id = x.c.Id,
                                Name = x.ct.Name
                            }).ToListAsync();
            var PagedResult = new PagedResultDto<CategoryVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return PagedResult;
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories

                        join ct in _context.CategoryTranslations
                        on c.Id equals ct.CategoryId

                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };

            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }
    }
}
