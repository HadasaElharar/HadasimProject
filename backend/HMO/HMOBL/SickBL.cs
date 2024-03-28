using AutoMapper;
using HmoDAL;
using HmoDAL.Models;
using HmoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HmoBL
{
    public class SickBL : ISickBL
    {
        ISickDL _sickDL;
        IMapper _mapper;

        public SickBL(ISickDL sickDL, IMapper mapper)
        {
            _sickDL = sickDL;
            _mapper = mapper;
        }

        public async Task<List<SickDTO>> GetAllSick()
        {
            try
            {
                List<Sick> sickList = await _sickDL.GetAllSick();
                List<SickDTO> sickDTOList = _mapper.Map<List<SickDTO>>(sickList);
                return sickDTOList;
            }
            catch (Exception ex)
            {
                // Handle exception
                return null;
            }
        }

        public async Task<SickDTO> AddSick(SickDTO sickDTO)
        {
            try
            {
                Sick sick = _mapper.Map<Sick>(sickDTO);
                Sick newSick = await _sickDL.AddSick(sick);
                SickDTO newSickDTO = _mapper.Map<SickDTO>(newSick);
                return newSickDTO;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
        }

        public async Task<SickDTO> UpdateSick(int id, SickDTO sickDTO)
        {
            try
            {
                Sick sick = _mapper.Map<Sick>(sickDTO);
                Sick updatedSick = await _sickDL.UpdateSick(id, sick);
                SickDTO updatedSickDTO = _mapper.Map<SickDTO>(updatedSick);
                return updatedSickDTO;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
        }

        public async Task<SickDTO> DeleteSick(int id)
        {
            try
            {
                Sick deletedSick = await _sickDL.DeleteSick(id);
                SickDTO deletedSickDTO = _mapper.Map<SickDTO>(deletedSick);
                return deletedSickDTO;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
        }

        public async Task<SickDTO> GetSickById(int id)
        {
            try
            {
                Sick sick = await _sickDL.GetSickById(id);
                SickDTO sickDTO = _mapper.Map<SickDTO>(sick);
                return sickDTO;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw ex;
            }
        }
    }
}
