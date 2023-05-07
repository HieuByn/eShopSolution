﻿using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbcontext _context;
        public PublicProductService(EShopDbcontext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<ProductViewModelDto>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _context.Products

                        join pt in _context.ProductTranslations
                        on p.Id equals pt.ProductId

                        join pic in _context.ProductInCategories
                        on p.Id equals pic.ProductId

                        join c in _context.Categories
                        on pic.CategoryId equals c.Id
                        select new { p, pt, pic };


            if (request.CategoryId > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new ProductViewModelDto()
                            {
                                Id = x.p.Id,
                                Name = x.pt.Name,
                                DateCreated = x.p.DateCreated,
                                Description = x.pt.Description,
                                Details = x.pt.Description,
                                LanguageId = x.pt.LanguageId,
                                OriginalPrice = x.p.OriginalPrice,
                                Price = x.p.Price,
                                SeoAlias = x.pt.SeoAlias,
                                SeoDescription = x.pt.SeoDescription,
                                SeoTitle = x.pt.SeoTitle,
                                Stock = x.p.Stock,
                                ViewCount = x.p.ViewCount
                            }).ToListAsync();

            var PagedResult = new PagedResultDto<ProductViewModelDto>()
            {
                ToTalRecord = totalRow,
                Items = data,
            };
            return PagedResult;
        }
    }
}
