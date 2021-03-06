using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intership.DTO
{
    public class ProductUpdateDTO
    {
        [MaxLength(50), Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        
    }
}
