namespace StarisApi.Dtos
{
    public class StarshipDto : IDto
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string StarshipClass { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string CostInCredits { get; set; } = null!;
        public string Lenght { get; set; } = null!;
        public string Crew { get; set; } = null!;
        public string Passengers { get; set; } = null!;
        public string MaxAtmospheringSpeed { get; set; } = null!;
        public string HyperDriveRating { get; set; } = null!;
        public string Megalights { get; set; } = null!;
        public string CargoCapacity { get; set; } = null!;
        public string Consumables { get; set; } = null!;
        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<ListDto> Movies { get; set; } = null!;
    }
}
