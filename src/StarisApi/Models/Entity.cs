using StarisApi.Dtos;
using StarisApi.Models.Characters;
using System.Globalization;

namespace StarisApi.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public abstract string GetSearchParameter();
        public abstract T ConvertToDto<T>() where T : class;


        public string? ValidateSortParameter(string? parameter)
        {
            if (parameter == null)
            {
                return null;
            }

            var validParametersUpper = this.GetType().GetProperties().Select(x => x.Name);
            var validParametersLower = validParametersUpper.Select(x => x.ToLower());
            var validParameters = validParametersUpper.Concat(validParametersLower);
            return validParameters.Contains(parameter) ? char.ToUpper(parameter[0], CultureInfo.InvariantCulture) + parameter[1..] : null;
        }
    }
}
