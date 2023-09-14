using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Products")]
    public class Products : BaseEntity<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? MarketPrice { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? ImportPrice { get; set; }
        public DateTime? DateOfManufacture { get; set; }

        // các trường khóa ngoại
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("BandsId")]
        public int? BandsId { get; set; }
        public Brand? Brand { get; set; }
    }
}
