using HmoBL;
using HmoDTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinatedController : Controller
    {
        // GET: HmoMemberController
        IVaccinatedBL _vaccinatedBL;
        public VaccinatedController(IVaccinatedBL vaccinatedBL)
        {
            _vaccinatedBL = vaccinatedBL;
        }



        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: HmoMemberController/Details/5
        [HttpGet]
        public async Task<List<VaccinatedDTO>> GetAllVaccinateds()
        {
            return await _vaccinatedBL.GetAllVaccinateds();
        }
        [HttpGet("{id}")]
        public async Task<List<VaccinatedDTO>> GetVaccinatedById(int id)
        {
            return await _vaccinatedBL.GetVaccinatedById(id);
        }
        [HttpPost]
        public async Task<VaccinatedDTO> AddVaccinated([FromBody] VaccinatedDTO vaccinatedDTO)
        {
            VaccinatedDTO newVaccinated = await _vaccinatedBL.AddVaccinated(vaccinatedDTO);
            return newVaccinated;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HmoMemberDTO>> UpdateVaccinated(int id, [FromBody] VaccinatedDTO vaccinatedDTO)
        {
            VaccinatedDTO isUpdate = await _vaccinatedBL.UpdateVaccinated(id, vaccinatedDTO);
            if (isUpdate != null)
            {
                return Ok(isUpdate);
            }
            return StatusCode(204, "update user failed: user is null");
        }
        [HttpDelete("{id}")]
        public async Task<VaccinatedDTO> DeleteVaccinated(int id)
        {
            VaccinatedDTO isDelete = await _vaccinatedBL.DeleteVaccinated(id);
            return isDelete;
        }


        // GET: HmoMemberController/Create
        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: HmoMemberController/Create
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create(IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: HmoMemberController/Edit/5
        //    public ActionResult Edit(int id)
        //    {
        //        return View();
        //    }

        //    // POST: HmoMemberController/Edit/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }

        //    // GET: HmoMemberController/Delete/5
        //    public ActionResult Delete(int id)
        //    {
        //        return View();
        //    }

        //    // POST: HmoMemberController/Delete/5
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Delete(int id, IFormCollection collection)
        //    {
        //        try
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            return View();
        //        }
        //    }
    }
}
