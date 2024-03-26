using HmoDAL.Models;

namespace HmoDAL
{
    public interface IHmoMemberDL
    {
        Task<HmoMember> AddHmoMember(HmoMember HmoMember);
        Task<HmoMember> DeleteHmoMember(int id);
        Task<List<HmoMember>> GetAllHmoMembers();
        Task<HmoMember> GeHmoMemberById(int id);
        Task<HmoMember> GetHmoMemberByIdCivil(int id);


        Task<HmoMember> UpdateHmoMember(int id, HmoMember hmoMember);
    }
}