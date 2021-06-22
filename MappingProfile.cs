using AutoMapper;
using MemberProject.DTO.Members;
using MemberProject.Models;

namespace MemberProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Members

            CreateMap<Member, MemberDto>().ReverseMap();

            #endregion
        }
    }
}
