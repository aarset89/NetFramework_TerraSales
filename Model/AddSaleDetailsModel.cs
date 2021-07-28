using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AddSaleDetailsModel
    {
        //[Required]
        [StringLength(200)]
        public string description { get; set; }
        public decimal price { get; set; }
    }
}
