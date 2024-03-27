using HmoDTO.DTO;

namespace HmoBL
{
    public interface IVaccinatedBL
    {
        Task<VaccinatedDTO> AddVaccinated(VaccinatedDTO vaccinatedDTO);
        Task<VaccinatedDTO> DeleteVaccinated(int id);
        Task<List<VaccinatedDTO>> GetAllVaccinateds();
        Task<List<VaccinatedDTO>> DeleteAllVaccinated(int id);
        Task <List<VaccinatedDTO>> GetVaccinatedById(int id);
        Task <VaccinatedDTO> UpdateVaccinated(int id, VaccinatedDTO vaccinatedDTO);

    }
}