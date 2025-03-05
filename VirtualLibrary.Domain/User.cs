
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VirtualLibrary.Domain.StudyRoomEntities;

namespace VirtualLibrary.Domain
{
    public class User : IdentityUser
    {
        private readonly ILazyLoader _lazyLoader;
        public string? Logo { get; set; }

        private List<StudyRoom>? _studyRooms;
        public List<StudyRoom> StudyRooms
        {
            get => _lazyLoader.Load(this, ref _studyRooms);
            set => _studyRooms = value;
        }

        public User(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
        public User() { }
    }
}
