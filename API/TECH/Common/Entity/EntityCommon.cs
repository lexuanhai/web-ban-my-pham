using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public enum CategoryStatus
    {
        [Description("Hiện thị")]
        IsShow = 0,
        [Description("Chờ duyệt")]
        Await = 1,        
    }

}
