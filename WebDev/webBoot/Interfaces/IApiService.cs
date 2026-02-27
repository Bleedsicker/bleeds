using Microsoft.AspNetCore.Mvc;

namespace WebDev.Interfaces;

public interface IApiService
{
    Task<HttpResponseMessage> PostAsync<T>(string url, T dto);
    Task<T> GetAsync<T>(string url);
    Task<HttpResponseMessage> DeleteAsync(string url);
}
