using StarisApi.Dtos;
using StarisApi.Requests;

namespace StarisApi.Responses
{
    public sealed class ResponseList<T, D> where T : IList<IDto> 
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int TotalPages { get; set; }
        public string Next { get; set; } = default!;
        public string Previous { get; set; } = default!;
        public IList<D> Results { get; set; } = [];

        public ResponseList(IList<D> lista, int total, Request request)
        {
            var dtoNameEndpoint = typeof(D).Name.Replace("Dto", string.Empty).ToLower();
            var host = Configurations.Configurations.Host;

            Results = lista;

            Count = total;
            Page = request.Page ?? 1;
            PerPage = request.PerPage ?? 10;
            TotalPages = (int)Math.Ceiling((double)Count / PerPage);
            Next = TotalPages > Page ? $"{host}/api/{dtoNameEndpoint}?page={Page + 1}" : $"{host}/api/{dtoNameEndpoint}?page={Page}";
            Previous = Page <= TotalPages ? $"{host}/api/{dtoNameEndpoint}?page={Page}" : $"{host}/api/{dtoNameEndpoint}?page={Page - 1}";
        }
    }

    
}
