using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        [Column(TypeName = "nvarchar(500)")]
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string? UpdatedBy { get; set; }

       

        /// <summary>
        /// True if domain entity has an identity
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }

}
