namespace StarisApi.Dtos
{
    public class PlanetDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string RotationSpeed { get; set; } = null!;
        public string OrbitalPeriod { get; set; } = null!;
        public string Diameter { get; set; } = null!;
        public string Climate { get; set; } = null!;
        public string Gravity { get; set; } = null!;
        public string Terrain { get; set; } = null!;
        public string SurfaceWater { get; set; } = null!;
        public string Population { get; set; } = null!;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<ListDto> Characters { get; set; } = null!;
        public ICollection<ListDto> Movies { get; set; } = null!;
    }
}
