using FluentValidation;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class UpdateCardFeature
    {
        public class UpdateCardValidations : AbstractValidator<UpdateCardCommand>
        {
            public UpdateCardValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}
