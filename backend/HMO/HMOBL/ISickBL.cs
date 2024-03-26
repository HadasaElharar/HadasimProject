using HmoDTO.DTO;

namespace HmoBL
{
    public interface ISickBL
    {
        Task<SickDTO> AddSick(SickDTO sickDTO);
        Task<SickDTO> DeleteSick(int id);
        Task<List<SickDTO>> GetAllSick();
        Task<SickDTO> GetSickById(int id);
        Task<SickDTO> UpdateSick(int id, SickDTO sickDTO);
    }
}