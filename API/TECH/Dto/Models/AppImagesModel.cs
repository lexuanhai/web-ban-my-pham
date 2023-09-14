using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppImagesModel 
    {
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? Alt { get; set; }      
    }
}
