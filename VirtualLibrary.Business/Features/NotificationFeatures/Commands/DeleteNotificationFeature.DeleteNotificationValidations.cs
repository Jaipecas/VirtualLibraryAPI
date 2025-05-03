using FluentValidation;

namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class DeleteNotificationFeature
    {
        public class DeleteNotificationValidations : AbstractValidator<DeleteNotificationCommand>
        {
           public DeleteNotificationValidations()
            {
                RuleFor(r => r.Id).NotEmpty();
            }
        }
    }
}
