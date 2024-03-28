using HmoBL;
using HmoDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SickController : ControllerBase
    {
        private readonly ISickBL _sickBL;

        public SickController(ISickBL sickBL)
        {
            _sickBL = sickBL;
        }

        [HttpGet]
        public async Task<ActionResult<List<SickDTO>>> GetAllSick()
        {
            var sickList = await _sickBL.GetAllSick();
            if (sickList == null)
            {
                return NotFound();
            }
            return Ok(sickList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SickDTO>> GetSickById(int id)
        {
            var sick = await _sickBL.GetSickById(id);
            if (sick == null)
            {
                return NotFound();
            }
            return Ok(sick);
        }

        [HttpPost]
        public async Task<ActionResult<SickDTO>> AddSick([FromBody] SickDTO sickDTO)
        {
            SickDTO newSick = await _sickBL.AddSick(sickDTO);
            return newSick;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSick(int id, [FromBody] SickDTO sickDTO)
        {
            var updatedSick = await _sickBL.UpdateSick(id, sickDTO);
            if (updatedSick == null)
            {
                return NotFound();
            }
            return Ok(updatedSick);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SickDTO>> DeleteSick(int id)
        {
            var deletedSick = await _sickBL.DeleteSick(id);
            if (deletedSick == null)
            {
                return NotFound();
            }
            return Ok(deletedSick);
        }
    }
}
