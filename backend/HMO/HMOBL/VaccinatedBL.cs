using AutoMapper;
using HmoDAL;
using HmoDAL.Models;
using HmoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoBL
{
    public class VaccinatedBL : IVaccinatedBL
    {
        IMapper _mapper;
        IVaccinatedDL _vaccinatedDL;
        public VaccinatedBL(IVaccinatedDL vaccinated, IMapper mapper)
        {
            this._mapper = mapper;
            _vaccinatedDL = vaccinated;
        }
        public async Task<List<VaccinatedDTO>> GetAllVaccinateds()
        {
            try
            {
                List<Vaccinated> vaccinated = await _vaccinatedDL.GetAllVaccinateds();
                List<VaccinatedDTO> vaccinatedDTOs = _mapper.Map<List<VaccinatedDTO>>(vaccinated);
                return vaccinatedDTOs;
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }

        public async Task <List<VaccinatedDTO>> GetVaccinatedById(int id)
        {
            try
            {
                List<Vaccinated> vaccinations = await _vaccinatedDL.GetVaccinatedById(id);
                List<VaccinatedDTO> vaccinatedDTOs = _mapper.Map<List<VaccinatedDTO>>(vaccinations);
                return vaccinatedDTOs;
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }
        public async Task<VaccinatedDTO> AddVaccinated(VaccinatedDTO vaccinatedDTO)
        {
            try
            {
                Vaccinated vaccinated = _mapper.Map<Vaccinated>(vaccinatedDTO);
                Vaccinated newVaccinated = await _vaccinatedDL.AddVaccinated(vaccinated);
                return _mapper.Map<VaccinatedDTO>(newVaccinated);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }
        public async Task<VaccinatedDTO> UpdateVaccinated(int id, VaccinatedDTO vaccinatedDTO)
        {
            try
            {
                Vaccinated vaccinated = _mapper.Map<Vaccinated>(vaccinatedDTO);
                Vaccinated updatedVaccinated = await _vaccinatedDL.UpdateVaccinated(id, vaccinated);
                return _mapper.Map<VaccinatedDTO>(updatedVaccinated);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }

        public async Task<VaccinatedDTO> DeleteVaccinated(int id)
        {
            try
            {
                Vaccinated deletedVaccinated = await _vaccinatedDL.DeleteVaccinated(id);
                return _mapper.Map<VaccinatedDTO>(deletedVaccinated);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }
    }
}
