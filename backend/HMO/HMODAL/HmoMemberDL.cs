using Microsoft.EntityFrameworkCore;
using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HmoDAL
{
    public class HmoMemberDL : IHmoMemberDL
    {
        HmoContext _hmoContext = new HmoContext();

        public async Task<List<HmoMember>> GetAllHmoMembers()
        {
            List<HmoMember> hmoMember = await _hmoContext.HmoMembers.ToListAsync();
            return hmoMember;

        }
        public async Task<HmoMember> AddHmoMember(HmoMember hmoMember)
        {
            try
            {
                await _hmoContext.HmoMembers.AddAsync(hmoMember);
                await _hmoContext.SaveChangesAsync();
                HmoMember newHmoMember = await _hmoContext.HmoMembers.OrderByDescending(item => item.Id).FirstOrDefaultAsync();
                return newHmoMember;
            }
            catch (Exception ex)
            {
                throw ex;
                return null;
            }

        }
        public async Task<HmoMember> UpdateHmoMember(int id, HmoMember hmoMember)
        {
            try
            {
                HmoMember currentHmoMemberToUpdate = _hmoContext.HmoMembers.Where(item => item.Id == id).FirstOrDefault();
                if (currentHmoMemberToUpdate == null)
                    throw new ArgumentException($"{id}isnot found");
                //currentUserToUpdate.UserId = user.UserId;
                else
                {
                    currentHmoMemberToUpdate.FullName = hmoMember.FullName;
                    currentHmoMemberToUpdate.Address = hmoMember.Address;
                    currentHmoMemberToUpdate.DateOfBirth = hmoMember.DateOfBirth;
                    currentHmoMemberToUpdate.Phone = hmoMember.Phone;
                    currentHmoMemberToUpdate.Mobile = hmoMember.Mobile;

                    await _hmoContext.SaveChangesAsync();
                    return currentHmoMemberToUpdate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HmoMember> DeleteHmoMember(int id)
        {
            try
            {
                HmoMember currentHmoMemberToDelete = await _hmoContext.HmoMembers.SingleOrDefaultAsync(item => item.IdCivil == id);
                if (currentHmoMemberToDelete == null)
                    throw new ArgumentException($"{id} is not found");
                _hmoContext.HmoMembers.Remove(currentHmoMemberToDelete);
                _hmoContext.SaveChangesAsync();
                return currentHmoMemberToDelete;
                //hththt\
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HmoMember> GeHmoMemberById(int id)
        {
            return await _hmoContext.HmoMembers.FirstOrDefaultAsync(item => item.Id == id);

        }
        public async Task<HmoMember> GetHmoMemberByIdCivil(int id)
        {
            return await _hmoContext.HmoMembers.FirstOrDefaultAsync(item => item.IdCivil == id);

        }


    }
}
