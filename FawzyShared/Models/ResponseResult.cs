using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawzyShared.Models
{
    public class ResponseResult<T>
    {
        public bool Status { get; set; }
        public T ROpject { get; set; }
    }
}
