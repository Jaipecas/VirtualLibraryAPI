using FluentValidation;

namespace VirtualLibrary.Application.Features.CardListFeatures.Command
{
    public partial class DeleteCardListFeature
    {
        public class DeleteCardListValidations : AbstractValidator<DeleteCardListCommand>
        {
            public DeleteCardListValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}
