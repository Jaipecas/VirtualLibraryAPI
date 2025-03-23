namespace VirtualLibrary.Application.Features.NotificationFeatures
{
    public partial class AddNotificationFeature
    {
        public class AddNotificationDto
        {
            public required int Id { get; set; }
            public required string SenderId { get; set; }
            public required string RecipientId { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
        }
        }
    }
}
