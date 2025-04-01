using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeStoreApiClient;
public class APIController<TEntity>( string baseUrl)
{
    private readonly HttpClient _httpClient = new HttpClient();

    public Task<TEntity> GetById(int id) => _httpClient.Get<TEntity>($"{baseUrl}/{id}");
    public Task<List<TEntity>> GetAll() => _httpClient.Get<List<TEntity>>($"{baseUrl}");
    public Task<TEntity> Create(TEntity entity) => _httpClient.Post($"{baseUrl}", entity);
    public Task Delete(int id) => _httpClient.Delete($"{baseUrl}/{id}");
    public Task Update(TEntity entity) => _httpClient.Put($"{baseUrl}", entity);
}
