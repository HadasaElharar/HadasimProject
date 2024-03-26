using HmoDTO.DTO;

namespace HmoBL
{
    public interface IHmoMemberBL

    {
        Task<HmoMemberDTO> AddHmoMember(HmoMemberDTO userDTO);
        Task<HmoMemberDTO> DeleteHmoMember(int id);
        Task<List<HmoMemberDTO>> GetAllHmoMembers();
        Task<HmoMemberDTO> GeHmoMemberById(int id);
        Task<HmoMemberDTO> GetHmoMemberByIdCivil(int id);

        Task<HmoMemberDTO> UpdateHmoMember(int id, HmoMemberDTO hmoMemberDTO);

    }
}