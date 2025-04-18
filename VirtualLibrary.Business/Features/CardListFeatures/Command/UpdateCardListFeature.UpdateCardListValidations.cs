using FluentValidation;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class UpdateCardListFeature
    {
        public class UpdateCardListValidations : AbstractValidator<UpdateCardListCommand>
        {
            public UpdateCardListValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                    RuleFor(r => r.Title).NotEmpty();
                }
            }
        }
    }
}
