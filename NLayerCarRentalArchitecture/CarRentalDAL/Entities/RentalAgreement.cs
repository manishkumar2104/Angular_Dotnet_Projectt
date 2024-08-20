using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Entities
{
    public class RentalAgreement
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public int Duration { get; set; }
        public int TotalCost { get; set; }
        public bool? IsRequestedForReturn { get; set; }
        public bool? IsReturnRequestAcceptedByAdmin { get; set; }
    }
}
