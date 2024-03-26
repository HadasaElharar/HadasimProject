using HmoDAL.Models;

namespace HmoDAL
{
    public interface IVaccinatedDL
    {
        Task<Vaccinated> AddVaccinated(Vaccinated vaccinated);
        Task<Vaccinated> DeleteVaccinated(int id);
        Task<List<Vaccinated>> GetAllVaccinateds();
        Task <List<Vaccinated>> GetVaccinatedById(int id);
        Task<Vaccinated> UpdateVaccinated(int id, Vaccinated vaccinated);
    }
}