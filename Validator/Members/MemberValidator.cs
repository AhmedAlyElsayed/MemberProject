using FluentValidation;
using MemberProject.DTO.Members;

namespace MemberProject.Validator.Members
{
    public class MemberValidator : AbstractValidator<MemberDto>
    {
        public MemberValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty().NotNull().WithMessage("Please specify Member Name");
        }
    }
}
