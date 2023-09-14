using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("AppColor")]
    public class AppColor : BaseEntity<int>
    {
        [Column(TypeName = "varchar(50)")]
        public string? Code { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
      
    }
}
