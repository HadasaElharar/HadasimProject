    using HmoBL;
using HmoDTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerBL _manufacturerBL;

        public ManufacturerController(IManufacturerBL manufacturerBL)
        {
            _manufacturerBL = manufacturerBL ?? throw new ArgumentNullException(nameof(manufacturerBL));
        }

        [HttpGet]
        public async Task<List<ManufacturerDTO>> GetAllManufacturers()
        {
            return await _manufacturerBL.GetAllManufacturers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerDTO>> GetManufacturerById(int id)
        {
            return await _manufacturerBL.GetManufacturerById(id);
        }
    }
}

//        [HttpPost]
//        public async Task<ActionResult<ManufacturerDTO>> AddManufacturer([FromBody] ManufacturerDTO manufacturerDTO)
//        {
//            try
//            {
//                ManufacturerDTO newManufacturer = await _manufacturerBL.AddManufacturer(manufacturerDTO);
//                return CreatedAtAction(nameof(GetManufacturerById), new { id = newManufacturer.Id }, newManufacturer);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the manufacturer.");
//            }
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<ManufacturerDTO>> UpdateManufacturer(int id, [FromBody] ManufacturerDTO manufacturerDTO)
//        {
//            try
//            {
//                ManufacturerDTO updatedManufacturer = await _manufacturerBL.UpdateManufacturer(id, manufacturerDTO);
//                if (updatedManufacturer == null)
//                {
//                    return NotFound($"Manufacturer with ID {id} not found.");
//                }
//                return Ok(updatedManufacturer);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the manufacturer.");
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ManufacturerDTO>> DeleteManufacturer(int id)
//        {
//            try
//            {
//                ManufacturerDTO deletedManufacturer = await _manufacturerBL.DeleteManufacturer(id);
//                if (deletedManufacturer == null)
//                {
//                    return NotFound($"Manufacturer with ID {id} not found.");
//                }
//                return Ok(deletedManufacturer);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the manufacturer.");
//            }
//        }
//    }
//}
