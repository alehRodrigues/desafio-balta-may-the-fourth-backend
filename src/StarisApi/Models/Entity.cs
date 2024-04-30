using System.Globalization;
using System.Text.Json;

namespace StarisApi.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public readonly string _imgUrlBase = "https://starwars.fandom.com/wiki/";
        public string ImageUrl { get; set; } = string.Empty;

        public abstract string GetSearchParameter();
        public abstract T ConvertToDto<T>()
            where T : class;
        public abstract T ConvertFromJson<T>(JsonElement info)
            where T : Entity;

        public string? ValidateSortParameter(string? parameter)
        {
            if (parameter == null)
            {
                return null;
            }

            var validParametersUpper = this.GetType().GetProperties().Select(x => x.Name);
            var validParametersLower = validParametersUpper.Select(x => x.ToLower());
            var validParameters = validParametersUpper.Concat(validParametersLower);
            return validParameters.Contains(parameter)
                ? char.ToUpper(parameter[0], CultureInfo.InvariantCulture) + parameter[1..]
                : null;
        }
    }
}
