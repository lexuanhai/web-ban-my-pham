using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("AppUser")]
    public class AppUser : BaseEntity<int>
    {
        [Column(TypeName = "nvarchar(500)")]
        public string? FullName { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? UserName { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Password { get; set; }
        [Column(TypeName = "varchar(11)")]
        public string? Phone { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? Address { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Email { get; set; }

    }
}
