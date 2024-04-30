using StarisApi.Models.Planets;

namespace StarisApi.Dtos
{
    public sealed class MovieDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Episode { get; set; } = null!;
        public string OpeningCrawl { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string Production { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<ListDto> Characters { get; set; } = null!;
        public ICollection<ListDto> Planets { get; set; } = null!;
        public ICollection<ListDto> Vehicles { get; set; } = null!;
        public ICollection<ListDto> Starships { get; set; } = null!;
    }
}
