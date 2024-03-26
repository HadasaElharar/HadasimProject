using HmoBL;
using HmoDTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hmo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HmoMemberController : Controller
    {
        // GET: HmoMemberController
        IHmoMemberBL _hmoMemberBL;
        public HmoMemberController(IHmoMemberBL hmoMemberBL)
        {
            _hmoMemberBL = hmoMemberBL;
        }



        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: HmoMemberController/Details/5
        [HttpGet]
        public async Task<List<HmoMemberDTO>> GetAllHmoMembers()
        {
            return await _hmoMemberBL.GetAllHmoMembers();
        }
        [HttpGet("{id}")]
        public async Task<HmoMemberDTO> GetHmoMemberById(int id)
        {
            return await _hmoMemberBL.GeHmoMemberById(id);
        }
        [HttpGet("GetHmoMemberByIdCivil")]
        public async Task<HmoMemberDTO> GetHmoMemberByIdCivil(int id)
        {
            return await _hmoMemberBL.GetHmoMemberByIdCivil(id);
        }
        [HttpPost]
        public async Task<HmoMemberDTO> AddHmoMember([FromBody] HmoMemberDTO hmoMemberDTO)
        {
            HmoMemberDTO newHmoMember = await _hmoMemberBL.AddHmoMember(hmoMemberDTO);
            return newHmoMember;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HmoMemberDTO>> UpdateHmoMember(int id, [FromBody] HmoMemberDTO hmoMemberDTO)
        {
            HmoMemberDTO isUpdate = await _hmoMemberBL.UpdateHmoMember(id, hmoMemberDTO);
            if (isUpdate != null)
            {
                return Ok(isUpdate);
            }
            return StatusCode(204, "update user failed: user is null");
        }
        [HttpDelete("{id}")]
        public async Task<HmoMemberDTO> DeleteHmoMember(int id)
        {
            HmoMemberDTO isDelete = await _hmoMemberBL.DeleteHmoMember(id);
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
