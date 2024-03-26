using AutoMapper;
using HmoDAL.Models;
using HmoDTO.DTO;


namespace HMODTO
{
    public class AutoMapping:Profile
    {
        public AutoMapping() 
        {
            CreateMap<HmoMember, HmoMemberDTO>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            CreateMap<Sick, SickDTO>().ReverseMap();
            CreateMap<Vaccinated, VaccinatedDTO>().ReverseMap();

        }

    }
}
