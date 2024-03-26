using AutoMapper;
using HmoDAL;
using HmoDAL.Models;
using HmoDTO.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HmoBL
{
    public class ManufacturerBL : IManufacturerBL
    {
         IMapper _mapper;
         IManufacturerDL _manufacturerDL;

        public ManufacturerBL(IManufacturerDL manufacturerDL, IMapper mapper)
        {
            _manufacturerDL = manufacturerDL ?? throw new ArgumentNullException(nameof(manufacturerDL));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ManufacturerDTO>> GetAllManufacturers()
        {
            try
            {
                List<Manufacturer> manufacturers = await _manufacturerDL.GetAllManufacturers();
                List<ManufacturerDTO> manufacturerDTOs = _mapper.Map<List<ManufacturerDTO>>(manufacturers);
                return manufacturerDTOs;
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }

        //public async Task<ManufacturerDTO> AddManufacturer(ManufacturerDTO manufacturerDTO)
        //{
        //    try
        //    {
        //        Manufacturer manufacturer = _mapper.Map<Manufacturer>(manufacturerDTO);
        //        Manufacturer newManufacturer = await _manufacturerDL.AddManufacturer(manufacturer);
        //        return _mapper.Map<ManufacturerDTO>(newManufacturer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception or log it
        //        throw;
        //    }
        //}

        //public async Task<ManufacturerDTO> UpdateManufacturer(int id, ManufacturerDTO manufacturerDTO)
        //{
        //    try
        //    {
        //        Manufacturer manufacturer = _mapper.Map<Manufacturer>(manufacturerDTO);
        //        Manufacturer updatedManufacturer = await _manufacturerDL.UpdateManufacturer(id, manufacturer);
        //        return _mapper.Map<ManufacturerDTO>(updatedManufacturer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception or log it
        //        throw;
        //    }
        //}

        //public async Task<ManufacturerDTO> DeleteManufacturer(int id)
        //{
        //    try
        //    {
        //        Manufacturer deletedManufacturer = await _manufacturerDL.DeleteManufacturer(id);
        //        return _mapper.Map<ManufacturerDTO>(deletedManufacturer);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception or log it
        //        throw;
        //    }
        //}

        public async Task<ManufacturerDTO> GetManufacturerById(int id)
        {
            try
            {
                Manufacturer manufacturer = await _manufacturerDL.GetManufacturerById(id);
                return _mapper.Map<ManufacturerDTO>(manufacturer);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                throw;
            }
        }
    }
}
