using HmoDAL.Models;

namespace HmoDAL
{
    public interface ISickDL
    {
        Task<Sick> AddSick(Sick sick);
        Task<Sick> DeleteSick(int id);
        Task<List<Sick>> GetAllSick();
        Task<Sick> GetSickById(int id);
        Task<Sick> UpdateSick(int id, Sick sick);
    }
}