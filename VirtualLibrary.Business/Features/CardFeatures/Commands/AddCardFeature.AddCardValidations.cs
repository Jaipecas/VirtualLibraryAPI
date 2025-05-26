using FluentValidation;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class AddCardFeature
    {
        public class AddCardValidations : AbstractValidator<AddCardCommand>
        {
            public AddCardValidations()
            {
                {
                    RuleFor(r => r.CardListId).NotEmpty().GreaterThan(0);
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }
    }
}
