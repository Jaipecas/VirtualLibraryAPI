using FluentValidation;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class AddCardListFeature
    {
        public class AddCardListValidations : AbstractValidator<AddCardListCommand>
        {
            public AddCardListValidations()
            {
                {
                    RuleFor(r => r.BoardId).NotEmpty().GreaterThan(0);
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }
    }
}
