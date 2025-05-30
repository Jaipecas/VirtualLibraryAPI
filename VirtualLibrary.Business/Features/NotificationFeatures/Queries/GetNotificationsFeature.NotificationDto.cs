﻿namespace VirtualLibrary.Application.Features.NotificationFeatures.Queries
{
    public partial class GetNotificationsFeature
    {
        public class NotificationDto
        {
            public required int Id { get; set; }
            public required string SenderName { get; set; }
            public required string Title { get; set; }
            public required string Message { get; set; }
            public required string NotificationType { get; set; }           
        }
    }
}
