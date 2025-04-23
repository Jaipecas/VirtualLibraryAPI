namespace VirtualLibrary.Application.Features.BoardFeatures.Queries
{
    public partial class GetBoardByIdFeature
    {
        public class GetBoardByIdDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required List<GetBoardByIdCardListDto> CardLists { get; set; }

        }

        public class GetBoardByIdCardListDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required List<GetBoardByIdCardDto> Cards { get; set; }
        }

        public class GetBoardByIdCardDto
        {
            public required int Id { get; set; }
            public required string Title { get; set; }
            public required bool IsComplete { get; set; }
        }

    }
}

