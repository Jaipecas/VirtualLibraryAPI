namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class NotificationDto
        {
            public required string Title { get; set; }
            public required string Message { get; set; }
            public required string NotificationType { get; set; }
        }
    }
}
