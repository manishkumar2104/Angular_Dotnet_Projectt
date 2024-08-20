using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Models
{
    public class CarFilterModel
    {
        public string? Maker {  get; set; }
        public string? Model { get; set; }
        public int? RentalPrice { get; set; }
    }
}
