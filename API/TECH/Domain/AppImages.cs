using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("AppImages")]
    public class AppImages : BaseEntity<int>
    {
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Url { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Alt { get; set; }      
    }
}
