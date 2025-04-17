using FluentValidation;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class UpdateBoardFeature
    {
        public class UpdateBoardValidations : AbstractValidator<UpdateBoardCommand>
        {
            public UpdateBoardValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }
    }
}
