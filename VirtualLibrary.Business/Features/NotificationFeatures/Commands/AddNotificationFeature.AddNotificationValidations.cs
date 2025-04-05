using FluentValidation;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature
    {
        public class AddNotificationValidations : AbstractValidator<AddNotificationCommand>
        {
            public AddNotificationValidations()
            {
            {
                RuleFor(r => r.SenderId).NotEmpty();
                RuleFor(r => r.RecipientName).NotEmpty();
                RuleFor(r => r.Title).NotEmpty();
                RuleFor(r => r.Message).NotEmpty();
            }
        }
        }
    }
}
