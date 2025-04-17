using FluentValidation;

namespace VirtualLibrary.Application.Features.BoardFeatures.Commands
{
    public partial class DeleteBoardFeature
    {
        public class DeleteBoardValidations : AbstractValidator<DeleteBoardCommand>
        {
            public DeleteBoardValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}
