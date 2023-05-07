using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Dtos
{
    public class PagedResultDto<T>
    {
        public List<T> Items { set; get; }
        public int ToTalRecord { set; get; }
    }
}
