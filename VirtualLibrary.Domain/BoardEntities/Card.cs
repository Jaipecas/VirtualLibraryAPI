

namespace VirtualLibrary.Domain.BoardEntities
{
    public class Card : GenericEntity
    {
        public required string Title { get; set; }
        public required int CardListId { get; set; }
    }
}
