using Newtonsoft.Json;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Services;

public class Order1Service : IOrder1Service
{
    private readonly string _baseurl = "https://localhost:7033/";
    private readonly string _endpoint = "api/Order1";

    public Order1Service()
    {
        
    }
    
    public async Task<Response<List<Order1Dto>>> GetAllAsync()
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<Order1Dto>>>(json);
        return response;
    }

    public async Task<Response<Order1Dto>> GetById(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Order1Dto>>(json);

        return response;    
    }

    public async Task<Response<Order1Dto>> SaveAsync(Order1Dto Order1)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(Order1);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<Order1Dto>>(json);

        return response;    
    }

    public async Task<Response<Order1Dto>> UpdateAsync(Order1Dto Order1)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(Order1);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<Order1Dto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);
        return response;
    }
}