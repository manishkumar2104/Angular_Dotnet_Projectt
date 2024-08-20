using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Models
{
    public class AgreementModel
    {
        public Guid? Id { get; set; }
        public Guid CarId { get; set; }
        public Guid? UserId { get; set; }
        public int Duration {  get; set; }
        public int TotalCost { get; set; }
        public bool? IsRequestedForReturn { get; set; }
        public bool? IsReturnRequestAcceptedByAdmin { get; set; }
    }
}
