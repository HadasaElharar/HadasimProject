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

            HmoMember Check = await _hmoContext.HmoMembers.Where(item => item.Id == vaccinated.MemberId).OrderByDescending(item => item.Id) // הוסף פרופרטי למיון, או השתמש בפרופרטי קיים
            .FirstOrDefaultAsync();

            if (Check != null && Check.CountVaccin < 4)
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
                Vaccinated currentVaccinToDelete = await _hmoContext.Vaccinateds.SingleOrDefaultAsync(item => item.MemberId == id);
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
        public async Task<List<Vaccinated>> DeleteAllVaccinated(int id)
        {
            try
            {
                List<Vaccinated> vaccinatedToDelete = await _hmoContext.Vaccinateds.Where(item => item.MemberId == id).ToListAsync();
                if (vaccinatedToDelete == null || vaccinatedToDelete.Count == 0)
                    throw new ArgumentException($"{id} is not found");

                // מחק את כל החיסונים המשויכים לחבר עם ה־ID שנשלח
                _hmoContext.Vaccinateds.RemoveRange(vaccinatedToDelete);

                // עדכן את ערך ה-CountVaccin בחבר עם ה־ID שנשלח
                HmoMember memberToUpdate = await _hmoContext.HmoMembers.FirstOrDefaultAsync(item => item.Id == id);
                if (memberToUpdate != null)
                {
                    memberToUpdate.CountVaccin = 0; // אפשר גם לעדכן את הערך בהתאם לצורך
                }

                await _hmoContext.SaveChangesAsync();

                return vaccinatedToDelete;
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
