using Common.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Category")]
    public class Category: BaseEntity<int>
    {
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; } = string.Empty;

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; } 

        public Category? CategoryParent { get; set; }

        public CategoryStatus? Status { get; set; }

    }
}
