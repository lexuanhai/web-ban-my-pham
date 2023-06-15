﻿using System;
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
        public string? Alt { get; set; }      
    }
}
