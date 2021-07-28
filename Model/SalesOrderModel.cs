using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SalesOrderModel
    {
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
    }
}
