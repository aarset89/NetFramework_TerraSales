using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EditSaleModel
    {
        [Required]
        public int OrderId { get; set; }
        public List<EditSaleDetailsModel> details { get; set; }
    }
}
