using maisesportes.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace maisesportes.Web.Services;

    public class AlunoAPI
{
    private readonly HttpClient _httpClient;
    public AlunoAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<AlunoResponse>?> GetAlunosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<AlunoResponse>>("alunos");
    }
}

