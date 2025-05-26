
using FluentValidation;

namespace VirtualLibrary.Application.Features.CardFeatures.Commands
{
    public partial class DeleteCardFeature
    {
        public class DeleteCardValidations : AbstractValidator<DeleteCardCommand>
        {
            public DeleteCardValidations()
            {
                {
                    RuleFor(r => r.Id).NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}
