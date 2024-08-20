using CarRentalDAL.DB;
using CarRentalDAL.Entities;
using CarRentalDAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalDAL.Repository
{
    public class AgreementRepository : IAgreementRepository
    {
        private readonly AppDBContext _appDBContext;
        public AgreementRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public async Task<RentalAgreement> PostCarBookingAgreement(RentalAgreement carRentalAgreement)
        {
            var agreement = await _appDBContext.RentalAgreements.AddAsync(carRentalAgreement);
            await _appDBContext.SaveChangesAsync();
            var rentedCar= await _appDBContext.Cars.FindAsync(carRentalAgreement.CarId);
            rentedCar.IsAvailableForRent = false;
            await _appDBContext.SaveChangesAsync();
            return agreement.Entity;
        }
        public async Task<List<RentalAgreement>> GetAllAgreements()
        {
            return await _appDBContext.RentalAgreements.ToListAsync();
        }

        public async Task<List<RentalAgreement>> GetAllUserAgreements(Guid userId)
        {
            var agreements= await _appDBContext.RentalAgreements.Where(agreement=> agreement.UserId==userId).ToListAsync();
            return agreements;
        }

        public async Task<RentalAgreement?>GetAgreementById(Guid id)
        {
            var agreement = await _appDBContext.RentalAgreements.FirstOrDefaultAsync(agreement=>agreement.Id==id);
            return agreement;
        }

        public async Task<bool>DeleteAgreement(RentalAgreement agreement)
        {
            var deletedAgreement=  _appDBContext.RentalAgreements.Remove(agreement);
            await _appDBContext.SaveChangesAsync();
            //setting car availability status after deleting the agreement
            var agreementCar= await _appDBContext.Cars.FirstOrDefaultAsync(car=>car.Id==agreement.CarId);
            agreementCar.IsAvailableForRent = true;
            await _appDBContext.SaveChangesAsync();
            return deletedAgreement.Entity.Id==agreement.Id;
        }

        public async Task<string> RequestReturn(Guid id)
        {
            var requestedAgreement= await _appDBContext.RentalAgreements.FirstOrDefaultAsync(agreement => agreement.Id==id);
            if (requestedAgreement == null)
            {
                return null;
            }
            requestedAgreement.IsRequestedForReturn= true;
            await _appDBContext.SaveChangesAsync();
            return "Request Submitted Successfully";
        }

        public async Task<bool>AcceptReturnRequest(Guid id)
        {
            var requestedAgreement = await _appDBContext.RentalAgreements.FirstOrDefaultAsync(agreement => agreement.Id == id);
            if (requestedAgreement == null || requestedAgreement.IsReturnRequestAcceptedByAdmin != null)
            {
                return false;
            }
            var rentedCar= await _appDBContext.Cars.FirstOrDefaultAsync(car=> car.Id==requestedAgreement.CarId);
            rentedCar.IsAvailableForRent = true;
            requestedAgreement.IsReturnRequestAcceptedByAdmin = true;
            await _appDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectReturnRequest(Guid id)
        {
            var requestedAgreement = await _appDBContext.RentalAgreements.FirstOrDefaultAsync(agreement => agreement.Id == id);
            if(requestedAgreement == null || requestedAgreement.IsReturnRequestAcceptedByAdmin != null)
            {
                return false;
            }
            requestedAgreement.IsReturnRequestAcceptedByAdmin= false;
            await _appDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<string> UpdateAgreement(RentalAgreement agreement)
        {
            var updatedagreement= _appDBContext.RentalAgreements.Update(agreement);
            await _appDBContext.SaveChangesAsync();
            return "Updated Successfully";
        }

        public async Task<List<RentalAgreement>> GetAllPendingReturnRequestAgreements()
        {
            var pendingReturnRequestAgreements = await _appDBContext.RentalAgreements.Where(agreement=> agreement.IsReturnRequestAcceptedByAdmin==null && agreement.IsRequestedForReturn==true).ToListAsync();
            if (pendingReturnRequestAgreements == null)
            {
                return null;
            }
            return pendingReturnRequestAgreements;
        }
    }
}
