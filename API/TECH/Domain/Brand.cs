﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Brand")]
    public class Brand : BaseEntity<int>
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public string? Address { get; set; }

    }
}