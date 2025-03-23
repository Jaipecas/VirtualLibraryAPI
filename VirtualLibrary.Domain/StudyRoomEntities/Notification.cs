
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.StudyRoomEntities
{
    public class Notification : GenericEntity
    {
        public required string SenderId { get; set; }

        private User? _sender;
        public User Sender
        {
            get => _lazyLoader.Load(this, ref _sender);
            set => _sender = value;
        }

        public required string RecipientId { get; set; }

        private User? _recipient;
        public User Recipient
        {
            get => _lazyLoader.Load(this, ref _recipient);
            set => _recipient = value;
        }

        public required string Title { get; set; }
        public required string Message { get; set; }


        private readonly ILazyLoader _lazyLoader;
        public Notification(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public Notification() { }
    }
}
