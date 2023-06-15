using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? MarketPrice { get; set; }
        public decimal? ImportPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }

        // các trường khóa ngoại
        public int? CategoryId { get; set; }
        public int? BandsId { get; set; }

    }
}
