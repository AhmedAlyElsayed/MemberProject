using MemberProject.Common.Interfaces;
using MemberProject.DTO.Members;
using MemberProject.Models;
using MemberProject.Repository.Members;
using MemberProject.Services.Generic;

namespace MemberProject.Services.Members
{
    public interface IMemberService : IGService<MemberDto, Member, IMemberRepository>
    {
        IResponseDTO GetAll(int? pageIndex = null, int? pageSize = null, MemberFilterDto filterDto = null);
    }
}
