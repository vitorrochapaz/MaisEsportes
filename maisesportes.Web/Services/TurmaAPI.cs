using maisesportes.Web.Requests;
using maisesportes.Web.Response;
using System.Net.Http;
using System.Net.Http.Json;

namespace maisesportes.Web.Services;

public class TurmaAPI
{
    private readonly HttpClient _httpClient;
    public TurmaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<TurmaResponse>?> GetTurmasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<TurmaResponse>>("Turmas");
    }

    public async Task AddTurmaAsync(TurmaRequest turma)
    {
        await _httpClient.PostAsJsonAsync("turmas", turma);
    }

    public async Task<TurmaResponse?> GetTurmaPorIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<TurmaResponse>($"turmas/{id}");
    }
}