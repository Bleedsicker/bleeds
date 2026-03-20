using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json;
using WebDev.Configuration;
using WebDev.Interfaces;

namespace WebDev.Services;

public class ApiService : IApiService
{
    private HttpClient _httpClient;
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("WebDevAPI");
    }

    public void UseApi(string clientName)
    {
        _httpClient = _httpClientFactory.CreateClient(clientName);
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string url, T dto)
    {
        return await _httpClient.PostAsJsonAsync(url, dto);
    }

    public async Task<T> GetAsync<T>(string url)
    {
        return await _httpClient.GetFromJsonAsync<T>(url);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string url)
    {
        return await _httpClient.DeleteAsync(url);
    }

}
