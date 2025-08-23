using maisesportes.Web.Requests;
using maisesportes.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace maisesportes.Web.Services;

public class ProfessorAPI
{
    private readonly HttpClient _httpClient;
    public ProfessorAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<ProfessorResponse>?> GetProfessorAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<ProfessorResponse>>("Professores");
    }

    public async Task AddProfessorAsync(ProfessorRequest professor)
    {
        await _httpClient.PostAsJsonAsync("professores", professor);
    }
    public async Task<ProfessorResponse?> GetProfessorPorIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProfessorResponse>($"professores/{id}");
    }
}