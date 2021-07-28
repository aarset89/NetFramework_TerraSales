using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DeleteOrderModel
    {
        [Required]
        public int OrderId { get; set; }
    }
}
