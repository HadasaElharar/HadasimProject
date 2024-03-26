using HmoDAL.Models;

namespace HmoDAL
{
    public interface IManufacturerDL
    {
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerById(int id);
    }
}