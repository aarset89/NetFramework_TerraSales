using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public partial class BaseOut
    {
        public Result Result { get; set; }
    }


    public enum Result
    {
        Success,
        Error,
        NotFound
    }
}
