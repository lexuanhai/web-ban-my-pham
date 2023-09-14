using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ProductQuantity")]
    public class ProductQuantity: BaseEntity<int>
    {               
        public int? TotalImported { get; set; }
        public int? TotalSold { get; set; }
        public int? TotalStock { get; set; }
        public int? TotalExpired { get; set; } // Tổng sản phẩm hết hạn

        // các trường khóa ngoại
        [ForeignKey("ColorId")]
        public int? ColorId { get; set; }
        public AppColor? AppColor { get; set; }
        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public Products? Products { get; set; }
    }
}
