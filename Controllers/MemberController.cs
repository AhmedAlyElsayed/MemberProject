using MemberProject.Common.Interfaces;
using MemberProject.DTO.Members;
using MemberProject.Services.Members;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MemberProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;
        private IResponseDTO responseDTO;

        public MemberController(IMemberService memberService, IResponseDTO responseDTO)
        {
            this.memberService = memberService;
            this.responseDTO = responseDTO;
        }

        [Route("AddMember")]
        [HttpPost]
        public async ValueTask<IResponseDTO> AddMember([FromBody] MemberDto memberDto)
        {
            responseDTO = await memberService.AddAsync(memberDto);

            return responseDTO;
        }

        [Route("RemoveMember")]
        [HttpPost]
        public IResponseDTO RemoveMember(int Id)
        {
            var expensesItemsDto = new MemberDto()
            {
                Id = Id
            };

            responseDTO = memberService.Remove(expensesItemsDto);

            return responseDTO;
        }

        [Route("GetMember")]
        [HttpGet]
        public IResponseDTO GetMember(int? pageIndex = null, int? pageSize = null, MemberFilterDto filterDto = null)
        {
            responseDTO = memberService.GetAll(pageIndex, pageSize, filterDto);

            return responseDTO;
        }
    }
}
