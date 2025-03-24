using FluentValidation;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature
    {
        public class DeleteNotificationValidations : AbstractValidator<DeleteNotificationCommand>
        {
            DeleteNotificationValidations()
            {
                RuleFor(r => r.Id).NotEmpty();
                RuleFor(r => r.IsAccepted).NotEmpty();
            }
        }
    }
}
