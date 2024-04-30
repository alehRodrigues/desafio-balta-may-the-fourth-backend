using System.Globalization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace StarisApi.Configurations.Attributtes
{
    /// <summary>
    /// Permite que o Swagger descreva todos os parâmetros em camelCase
    /// </summary>
    public class ParameterAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var str = parameter.Name;

                if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                {
                    parameter.Name = char.ToLower(str[0], CultureInfo.InvariantCulture) + str[1..];
                }
            }
        }
    }
}
