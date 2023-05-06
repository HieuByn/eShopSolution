using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagedViewModel<T>
    {
        List<T> Items { set; get; }
        public int ToTalRecord { set; get; }
    }
}
