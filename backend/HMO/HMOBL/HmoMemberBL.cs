using AutoMapper;
using HmoDAL;
using HmoDAL.Models;
using HmoDTO.DTO;

namespace HmoBL
{
    public class HmoMemberBL : IHmoMemberBL
    {
        public IMapper _mapper;

        IHmoMemberDL _hmomemberDL;

        public HmoMemberBL(IHmoMemberDL hmoMember, IMapper mapper)
        {
            this._mapper = mapper;
            _hmomemberDL = hmoMember;
        }
        public async Task<List<HmoMemberDTO>> GetAllHmoMembers()
        {
            try
            {
                List<HmoMember> hmoMember = await _hmomemberDL.GetAllHmoMembers();
                List<HmoMemberDTO> hmoMemberDTO = _mapper.Map<List<HmoMember>, List<HmoMemberDTO>>(hmoMember);
                return hmoMemberDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<HmoMemberDTO> AddHmoMember(HmoMemberDTO hmoMemberDTO)

        {

            //string dateString = $"{hmoMemberDTO.DateOfBirth.Year}-{hmoMemberDTO.DateOfBirth.Month}-{hmoMemberDTO.DateOfBirth.Day}";
           
            HmoMember hmoMember = _mapper.Map<HmoMember>(hmoMemberDTO);

           // hmoMember.DateOfBirth= dateString;

            HmoMember newHmoMember = await _hmomemberDL.AddHmoMember(hmoMember);

            //DateOnly dateOnly = hmoMemberDTO.DateOfBirth;

            HmoMemberDTO ToRet =  _mapper.Map<HmoMemberDTO>(newHmoMember);
          //  ToRet.DateOfBirth = dateOnly;
            return ToRet;

        }
        public async Task<HmoMemberDTO> UpdateHmoMember(int id, HmoMemberDTO hmoMemberDTO)
        {
            HmoMember hmoMember = _mapper.Map<HmoMember>(hmoMemberDTO);
            HmoMember updatedHmoMember = await _hmomemberDL.UpdateHmoMember(id, hmoMember);
            return _mapper.Map<HmoMemberDTO>(updatedHmoMember);
        }
        public async Task<HmoMemberDTO> DeleteHmoMember(int id)
        {
            int u = _mapper.Map<int>(id);
            HmoMember updatedUser = await _hmomemberDL.DeleteHmoMember(id);

            return _mapper.Map<HmoMemberDTO>(updatedUser);
        }
        public async Task<HmoMemberDTO> GeHmoMemberById(int id)
        {
            HmoMember hmoMember = await _hmomemberDL.GeHmoMemberById(id);
            return _mapper.Map<HmoMemberDTO>(hmoMember);
        }
       
        public async Task<HmoMemberDTO> GetHmoMemberByIdCivil(int id)
        {
            HmoMember hmoMember = await _hmomemberDL.GetHmoMemberByIdCivil(id);
            return _mapper.Map<HmoMemberDTO>(hmoMember);
        }

    }
}
