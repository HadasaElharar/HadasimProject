using Microsoft.EntityFrameworkCore;
using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmoDAL
{
    public class SickDL : ISickDL
    {
        HmoContext _hmoContext = new HmoContext();

        
        public async Task<List<Sick>> GetAllSick()
        {
            List<Sick> sick = await _hmoContext.Sicks.ToListAsync();
            return sick;
        }

        public async Task<Sick> AddSick(Sick sick)
        {
            try
            {
                _hmoContext.Sicks.AddAsync(sick);
                await _hmoContext.SaveChangesAsync();
                Sick newSick = await _hmoContext.Sicks.OrderByDescending(item => item.Id).FirstOrDefaultAsync();
                return newSick;
            }
            catch (Exception ex)
            {
                throw ex;
                return null; ;
            }
        }

        public async Task<Sick> UpdateSick(int id, Sick sick)
        {
            try
            {
                Sick currentSickToUpdate = _hmoContext.Sicks.Where(item => item.Id == id).FirstOrDefault();
                if (currentSickToUpdate == null)
                {
                    throw new ArgumentException($"Sick with ID {id} is not found.");
                }
                else
                {
                    currentSickToUpdate.Id = sick.Id;
                    currentSickToUpdate.MemberId = sick.MemberId;
                    currentSickToUpdate.PssitiveDate = sick.PssitiveDate;
                    currentSickToUpdate.RecoveryDate = sick.RecoveryDate;

                    await _hmoContext.SaveChangesAsync();
                    return currentSickToUpdate;

                }

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sick> DeleteSick(int id)
        {
            try
            {
                Sick currentSickToDelete = await _hmoContext.Sicks.SingleOrDefaultAsync(item => item.Id == id);
                if (currentSickToDelete == null)
                    throw new ArgumentException($"{id} is not found");
                _hmoContext.Sicks.Remove(currentSickToDelete);
                _hmoContext.SaveChangesAsync();
                return currentSickToDelete;
                //hththt\
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sick> GetSickById(int id)
        {
            return await _hmoContext.Sicks.FirstOrDefaultAsync(item => item.MemberId == id);
        }
    }
}
