using maisesportes.Web.Requests;
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
        return await _httpClient.GetFromJsonAsync<ICollection<AlunoResponse>>("Alunos");
    }

    public async Task AddAlunoAsync(AlunoRequest aluno)
    {
        await _httpClient.PostAsJsonAsync("alunos", aluno);
    }

    public async Task<AlunoResponse?> GetAlunoPorIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<AlunoResponse>($"alunos/{id}");
    }
}

