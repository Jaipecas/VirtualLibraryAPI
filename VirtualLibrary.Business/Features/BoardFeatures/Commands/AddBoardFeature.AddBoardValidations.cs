using FluentValidation;

namespace VirtualLibrary.Application.Features.BoardFeatures
{
    public partial class AddBoardFeature
    {
        public class AddBoardValidations : AbstractValidator<AddBoardCommand>
        {
            public AddBoardValidations()
            {
                {
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }

    }
}
