using System;
using System.Text;
using System.Text.Json;

namespace FakeStoreApiClient;
public static class HttpExtnesion
{
    private static JsonSerializerOptions serializeOptions = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };


    private delegate Task<HttpResponseMessage> ApiMethodAsync(string url, HttpContent content);

    public static async Task<TResult> Get<TResult>(this HttpClient httpClient, string url)
        => await DeserializeResponse<TResult>(await httpClient.GetAsync(url));

    public static async Task<TResult> Delete<TResult, TEntity>(this HttpClient httpClient, string url, TEntity entity)
      => await DeserializeResponse<TResult>(await httpClient.DeleteAsync(url));

    public static async Task Delete(this HttpClient httpClient, string url)
      => await httpClient.DeleteAsync(url);


    public static async Task<TResult> Post<TResult, TEntity>(this HttpClient httpClient, string url, TEntity entity)
        => await HandleMethod<TResult, TEntity>(url, entity, httpClient.PostAsync);

    public static async Task<TEntity> Post<TEntity>(this HttpClient httpClient, string url, TEntity entity)
        => await HandleMethod<TEntity, TEntity>(url, entity, httpClient.PostAsync);

    public static async Task<TResult> Put<TResult, TEntity>(this HttpClient httpClient, string url, TEntity entity)
       => await HandleMethod<TResult, TEntity>(url, entity, httpClient.PutAsync);

    public static async Task<TEntity> Put<TEntity>(this HttpClient httpClient, string url, TEntity entity)
       => await HandleMethod<TEntity, TEntity>(url, entity, httpClient.PutAsync);

    public static async Task<TResult> Patch<TResult, TEntity>(this HttpClient httpClient, string url, TEntity entity)
       => await HandleMethod<TResult, TEntity>(url, entity, httpClient.PatchAsync);

    public static async Task<TEntity> Patch<TEntity>(this HttpClient httpClient, string url, TEntity entity)
      => await HandleMethod<TEntity, TEntity>(url, entity, httpClient.PatchAsync);



    private static async Task<TResult> HandleMethod<TResult, TEntity>(string url, TEntity entity, ApiMethodAsync method)
    {
        var content = SerializeRequest(entity);
        var response = await method(url, content);
        return await DeserializeResponse<TResult>(response);
    }


    private static async Task<TResult> DeserializeResponse<TResult>(HttpResponseMessage response)
    {
        try
        {

            var result = JsonSerializer.Deserialize<TResult>(await response.Content.ReadAsStringAsync(), serializeOptions);
            return result;
        }

        catch (Exception ex) {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        
    }

    private static StringContent SerializeRequest<T>(T entity)
    {
        var json = JsonSerializer.Serialize(entity, serializeOptions);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}
