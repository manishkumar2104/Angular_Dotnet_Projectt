using CarRentalDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.IRepository
{
    public interface IAgreementRepository
    {
        public Task<RentalAgreement> PostCarBookingAgreement(RentalAgreement carRentalAgreement);
        public Task<List<RentalAgreement>> GetAllAgreements();
        public Task<List<RentalAgreement>> GetAllUserAgreements(Guid userId);
        public Task<RentalAgreement?> GetAgreementById(Guid id);
        public Task<bool> DeleteAgreement(RentalAgreement agreement);
        public Task<string> RequestReturn(Guid id);
        public Task<bool> AcceptReturnRequest(Guid id);
        public Task<bool> RejectReturnRequest(Guid id);
        public Task<string>UpdateAgreement(RentalAgreement agreement);
        public Task<List<RentalAgreement>> GetAllPendingReturnRequestAgreements();
    }
}
