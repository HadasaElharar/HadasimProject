using HmoDTO.DTO;

namespace HmoBL
{
    public interface IManufacturerBL
    {
        Task<List<ManufacturerDTO>> GetAllManufacturers();
        Task<ManufacturerDTO> GetManufacturerById(int id);
    }
}