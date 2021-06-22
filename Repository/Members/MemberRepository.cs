using MemberProject.Models;
using MemberProject.Repository.Generic;

namespace MemberProject.Repository.Members
{
    public class MemberRepository : GRepository<Member>, IMemberRepository
    {
        private readonly MemberdbContext _appDbContext;
        public MemberRepository(MemberdbContext dbContext) 
            : base(dbContext)
        {
            _appDbContext = dbContext;
        }
    }
}
