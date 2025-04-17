
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VirtualLibrary.Domain.BoardEntities
{
    public class CardList
    {
        public required string Title { get; set; }       
        public required int BoardId { get; set; }

        private List<Card>? _cards;
        public List<Card>? Cards
        {
            get => _lazyLoader.Load(this, ref _cards);
            set => _cards = value;
        }

        private readonly ILazyLoader _lazyLoader;
        public CardList(ILazyLoader lazyLoader) => _lazyLoader = lazyLoader;
    }
}
