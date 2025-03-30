using FluentValidation;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserDataByIdFeature
    {
        public class GetUserDataByIdValidation : AbstractValidator<GetUserDataByIdQuery>
        {
            public GetUserDataByIdValidation()
            {
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}
