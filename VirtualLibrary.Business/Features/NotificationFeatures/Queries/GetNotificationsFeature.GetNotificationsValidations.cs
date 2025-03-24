using FluentValidation;

namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class GetNotificationsValidations : AbstractValidator<GetNoticationsQuery>
        {
            public GetNotificationsValidations()
            {
                RuleFor(r => r.UserId).NotEmpty();
            }
        }
    }
}
