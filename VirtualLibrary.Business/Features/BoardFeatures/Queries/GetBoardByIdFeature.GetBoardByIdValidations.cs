using FluentValidation;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature
    {
        public class GetBoardByIdValidations : AbstractValidator<GetBoardByIdQuery>
        {
            public GetBoardByIdValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                }
            }
        }

    }
}

