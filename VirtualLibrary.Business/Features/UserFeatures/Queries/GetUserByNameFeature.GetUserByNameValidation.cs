using FluentValidation;

namespace VirtualLibrary.Application.Features.UserFeatures.Queries
{
    public partial class GetUserByNameFeature
    {
        public class GetUserByNameValidation : AbstractValidator<GetUserByNameQuery>
        {
            public GetUserByNameValidation()
            {
                RuleFor(r => r.UserName).NotEmpty();
            }
        }
    }
}
