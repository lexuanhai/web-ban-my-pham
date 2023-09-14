using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("ProductImages")]
    public class ProductImages : BaseEntity<int>
    {

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }
        public Products? Products { get; set; }

        [ForeignKey("AppImageId")]
        public int? AppImageId { get; set; }
        public AppImages? AppImages { get; set; }
    }
}
