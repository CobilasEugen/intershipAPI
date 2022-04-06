using intership.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace intership.DTO
{
    public class ProductCreateDTO
    {
        [Key]
        private DateTime currentTime;
        public Guid id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime CreatedOn { get { return currentTime; } set { currentTime = DateTime.Now; } }

        [ForeignKey("Store")]
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
    }
}
