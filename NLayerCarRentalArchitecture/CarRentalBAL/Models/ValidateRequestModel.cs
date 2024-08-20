using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Models
{
    public class ValidateRequestModel
    {
        [Required]
        public string agreementId {  get; set; }
        [Required]
        public bool isAccepted { get; set; }
    }
}
