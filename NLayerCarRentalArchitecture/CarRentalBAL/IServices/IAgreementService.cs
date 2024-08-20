using CarRentalBAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.IServices
{
    public interface IAgreementService
    {
        public Task<bool> CreateCarBookingAgreement(AgreementModel agreement);
        public Task<List<AgreementModel>> GetAllAgreements();
        public Task<List<AgreementModel>> GetAllUserAgreements();
        public Task<bool> AgreementExist(string id);
        public Task<AgreementModel> GetAgreementById(string id);
        public Task<bool> DeleteAgreement(string id);
        public Task<string> RequestReturn(string id);
        public Task<string> ValidateReturnRequest(ValidateRequestModel requestData);
        public Task<string> UpdateAgreement(AgreementModel agreement);
        public Task<List<AgreementModel>> GetAllReturnRequestAgreements();
    }
}
