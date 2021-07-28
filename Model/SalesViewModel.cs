using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SalesViewModel : BaseOut
    {
        public SalesOrderModel salesOrder { get; set; }
        public List<SalesOrderDetailsModel> salesOrderDetails { get; set; }
    }
}
