using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreConcepts
{
    public class HttpClientFactoryService : IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        public HttpClientFactoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<DepartmentDto>> Execute()
        {
            return await GetDepartmentsWithHttpClientFactory();
        }

        private async Task<IEnumerable<DepartmentDto>> GetDepartmentsWithHttpClientFactory()
        {
            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync("https://localhost:44393/api/Dapper/GetAll", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<List<DepartmentDto>>(stream, _options);
            }
        }
    }

    public interface IHttpClientServiceImplementation
    {
        public Task<IEnumerable<DepartmentDto>> Execute();
    }
}
