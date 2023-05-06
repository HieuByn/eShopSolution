using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos
{
    public class ProductCreateRequestDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
