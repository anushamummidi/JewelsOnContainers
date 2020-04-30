using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Catalog      // Here Catalog means PaginatedViewModels from services
    {
        public int PageSize { get; set; }
        public int PageIndedx { get; set; }
        public long Count { get; set; }
        public List<CatalogItem> Data { get; set; }
    }
}
