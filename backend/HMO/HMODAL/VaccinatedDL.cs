using Microsoft.EntityFrameworkCore;
using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HmoDAL
{
    public class VaccinatedDL : IVaccinatedDL
    {
        HmoContext _hmoContext = new HmoContext();

        public async Task<List<Vaccinated>> GetAllVaccinateds()
        {
            List<Vaccinated> vaccinated = await _hmoContext.Vaccinateds.ToListAsync();
            
            return vaccinated;

        }
        public async Task<Vaccinated> AddVaccinated(Vaccinated vaccinated)
        {
            HmoMember Check = _hmoContext.HmoMembers.Where(item => item.IdCivil == vaccinated.MemberId).FirstOrDefault();

            if (Check.CountVaccin < 4)
            {
                try
                {
                    await _hmoContext.Vaccinateds.AddAsync(vaccinated);
                    Check.CountVaccin++;
                    await _hmoContext.SaveChangesAsync();
                    Vaccinated newVaccinated = await _hmoContext.Vaccinateds.OrderByDescending(item => item.Id).FirstOrDefaultAsync();
                    return newVaccinated;
                }
                catch (Exception ex)
                {
                    throw ex;
                    return null;
                }

            }
            else
            {
                return null;
            }

        }
        public async Task<Vaccinated> UpdateVaccinated(int id, Vaccinated vaccinated)
        {
            try
            {
                Vaccinated currentVaccinatedToUpdate = _hmoContext.Vaccinateds.Where(item => item.Id == id).FirstOrDefault();

                if (currentVaccinatedToUpdate == null)
                    throw new ArgumentException($"{id}isnot found");
                //currentUserToUpdate.UserId = user.UserId;
                else
                {

                    await _hmoContext.SaveChangesAsync();
                    return currentVaccinatedToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Vaccinated> DeleteVaccinated(int id)
        {
            try
            {
                Vaccinated currentVaccinToDelete = await _hmoContext.Vaccinateds.SingleOrDefaultAsync(item => item.Id == id);
                if (currentVaccinToDelete == null)
                    throw new ArgumentException($"{id} is not found");
                _hmoContext.Vaccinateds.Remove(currentVaccinToDelete);
                HmoMember Check = _hmoContext.HmoMembers.Where(item => item.Id == id).FirstOrDefault();
                Check.CountVaccin--;
                _hmoContext.SaveChangesAsync();
                return currentVaccinToDelete;
                //hththt\
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Vaccinated>> GetVaccinatedById(int id)
        {
            List<Vaccinated> vaccinations = await _hmoContext.Vaccinateds.Where(item => item.MemberId == id).ToListAsync();
            return vaccinations;

        }


    }
}
