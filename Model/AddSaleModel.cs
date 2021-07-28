using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AddSaleModel
    {
        [Required]
        [StringLength(50)]
        public string userName { get; set; }
        public List<AddSaleDetailsModel> details { get; set; }
    }
}
