using FluentValidation;

namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetAllBoardsFeature
    {
        public class GetAllBoardsValidations : AbstractValidator<GetAllBoardsQuery>
        {
            public GetAllBoardsValidations()
            {
                {
                    RuleFor(r => r.UserId).NotEmpty();
                }
            }
        }
    }
}
