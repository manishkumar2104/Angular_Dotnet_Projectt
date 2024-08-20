using AutoMapper;
using CarRentalBAL.Helper;
using CarRentalBAL.IServices;
using CarRentalBAL.Models;
using CarRentalDAL.Entities;
using CarRentalDAL.IRepository;
using CarRentalDAL.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.Services
{
    public class AgreementService: IAgreementService
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly AuthHelper _helper;
        private Mapper _agreementMapper;
        public AgreementService(IAgreementRepository agreementRepository, IHttpContextAccessor httpContextAccessor)
        {
            _agreementRepository = agreementRepository;
            _helper= new AuthHelper(httpContextAccessor);
            var _configAgreement = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RentalAgreement, AgreementModel>().ReverseMap();
            });
            this._agreementMapper = new Mapper(_configAgreement);
        }

        public async Task<bool> CreateCarBookingAgreement(AgreementModel agreement)
        {
            var userData = _helper.GetUserData();
            var agreementEntity = new RentalAgreement()
            {
                Id = new Guid(),
                CarId = agreement.CarId,
                UserId = Guid.Parse(userData.UserId),
                Duration = agreement.Duration,
                TotalCost = agreement.TotalCost,
                IsRequestedForReturn = false
            };
            var result= await _agreementRepository.PostCarBookingAgreement(agreementEntity);
            if(result==null)
            {
                return false;
            }
            return true;
        }
        public async Task<List<AgreementModel>> GetAllAgreements()
        {
            var allAgreements = await _agreementRepository.GetAllAgreements();
            if (allAgreements == null)
            {
                return null;
            }
            List<AgreementModel> result = _agreementMapper.Map<List<RentalAgreement>, List<AgreementModel>>(allAgreements);
            return result;
        }

        public async Task<List<AgreementModel>>GetAllUserAgreements()
        {
            var userData= _helper.GetUserData();
            var userId = Guid.Parse(userData.UserId);
            List<RentalAgreement> allUserAgreement = await _agreementRepository.GetAllUserAgreements(userId);
            if (allUserAgreement.Count == 0)
            {
                return null;
            }
            List<AgreementModel> userAgreements = _agreementMapper.Map<List<RentalAgreement>, List<AgreementModel>>(allUserAgreement);
            return userAgreements; 
        }

        public async Task<bool> AgreementExist(string id)
        {
            var agreementId= Guid.Parse(id);
            var result = await _agreementRepository.GetAgreementById(agreementId);
            if(result == null)
            {
                return false;
            }
            return true;
        }
        public async Task<AgreementModel>GetAgreementById(string id)
        {
            var agreementId = Guid.Parse(id);
            var result = await _agreementRepository.GetAgreementById(agreementId);
            var agreement = _agreementMapper.Map<RentalAgreement, AgreementModel>(result);
            return agreement;
        }

        public async Task<bool>DeleteAgreement(string  id)
        {
            var existingAgreement = await _agreementRepository.GetAgreementById(Guid.Parse(id));
            if (existingAgreement == null)
            {
                return false;
            }
            var result = await _agreementRepository.DeleteAgreement(existingAgreement);
            return result;
        }
        
        public async Task<string>RequestReturn(string id)
        {
            var agreementId= Guid.Parse(id);
            var result = await _agreementRepository.RequestReturn(agreementId);
            return result;
        }

        public async Task<string>ValidateReturnRequest(ValidateRequestModel requestData)
        {
            if (requestData.isAccepted == true)
            {
                var result = await _agreementRepository.AcceptReturnRequest(Guid.Parse(requestData.agreementId));
                if (result == false)
                {
                    return null;
                }
                return "Request Accepted Successfully";
            }
            else
            {
                var result= await _agreementRepository.RejectReturnRequest(Guid.Parse(requestData.agreementId));
                if (result == false)
                {
                    return null;
                }
                return "Request Rejected Successfully";
            }
        }

        public async Task<string>UpdateAgreement(AgreementModel agreement)
        {
            RentalAgreement updatedAgreement= _agreementMapper.Map<AgreementModel,RentalAgreement>(agreement);
            var result = await _agreementRepository.UpdateAgreement(updatedAgreement);
            return result;
        }

        public async Task<List<AgreementModel>> GetAllReturnRequestAgreements()
        {
            var allPendingReturnRequestAgreementsFromDB = await _agreementRepository.GetAllPendingReturnRequestAgreements();
            if(allPendingReturnRequestAgreementsFromDB == null)
            {
                return null;
            }
            List<AgreementModel> allPendingReturnRequestAgreements = _agreementMapper.Map<List<RentalAgreement>, List<AgreementModel>>(allPendingReturnRequestAgreementsFromDB);
            return allPendingReturnRequestAgreements;
        }
    }
}
