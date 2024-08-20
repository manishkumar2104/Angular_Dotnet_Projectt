using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int RentalPrice { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailableForRent { get; set; }
    }
}
