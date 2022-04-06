using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace intership.DTO
{
    public class StoreUpdateDTO
    {
        public Guid id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int MonthlyIncome { get; set; }
        public string OwnerName { get; set; }
        public DateTime ActiveSince { get; set; }
    }
}
