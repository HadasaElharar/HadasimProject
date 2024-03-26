using Microsoft.EntityFrameworkCore;
using HmoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmoDAL
{
    public class ManufacturerDL : IManufacturerDL
    {
        HmoContext _hmoContext = new HmoContext();

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            List<Manufacturer> manufacturers = await _hmoContext.Manufacturers.ToListAsync();
            return manufacturers;
        }

        //public async Task<Manufacturer> AddManufacturer(Manufacturer manufacturer)
        //{
        //    try
        //    {
        //        await _hmoContext.Manufacturers.AddAsync(manufacturer);
        //        await _hmoContext.SaveChangesAsync();
        //        Manufacturer newManufacturer = await _hmoContext.Manufacturers.OrderByDescending(item => item.Id).FirstOrDefaultAsync();
        //        return newManufacturer;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<Manufacturer> UpdateManufacturer(int id, Manufacturer manufacturer)
        //{
        //    try
        //    {
        //        Manufacturer currentManufacturerToUpdate = await _hmoContext.Manufacturers.FindAsync(id);
        //        if (currentManufacturerToUpdate == null)
        //            throw new ArgumentException($"{id} is not found");

        //        currentManufacturerToUpdate.Name = manufacturer.Name;
        //        currentManufacturerToUpdate.Address = manufacturer.Address;
        //        currentManufacturerToUpdate.Phone = manufacturer.Phone;
        //        currentManufacturerToUpdate.Email = manufacturer.Email;

        //        await _hmoContext.SaveChangesAsync();
        //        return currentManufacturerToUpdate;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<Manufacturer> DeleteManufacturer(int id)
        //{
        //    try
        //    {
        //        Manufacturer currentManufacturerToDelete = await _hmoContext.Manufacturers.FindAsync(id);
        //        if (currentManufacturerToDelete == null)
        //            throw new ArgumentException($"{id} is not found");

        //        _hmoContext.Manufacturers.Remove(currentManufacturerToDelete);
        //        await _hmoContext.SaveChangesAsync();

        //        return currentManufacturerToDelete;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<Manufacturer> GetManufacturerById(int id)
        {
            return await _hmoContext.Manufacturers.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
