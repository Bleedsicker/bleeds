namespace WebDev.Interfaces;

public interface IApiService
{
    Task<HttpResponseMessage> PostAsync<T>(string url, T dto);
}
