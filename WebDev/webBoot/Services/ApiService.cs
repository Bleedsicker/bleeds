using WebDev.Configuration;
using WebDev.Interfaces;

namespace WebDev.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ApiSettings _apiSettings;

    public ApiService(HttpClient httpClient, ApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _apiSettings = apiSettings;
        _httpClient.DefaultRequestHeaders.Add("WebDev-api-key", _apiSettings.ApiKey);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string url, T dto)
    {
        var dbg = string.Join(", ",
    _httpClient.DefaultRequestHeaders.Select(h => $"{h.Key}={string.Join("|", h.Value)}"));
        return await _httpClient.PostAsJsonAsync($"{_apiSettings.BaseUrl}/{url}", dto);
    }
}
