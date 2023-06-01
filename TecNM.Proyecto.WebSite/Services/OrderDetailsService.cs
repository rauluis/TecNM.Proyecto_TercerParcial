using Newtonsoft.Json;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly string _baseurl = "https://localhost:7033/";
    private readonly string _endpoint = "api/OrderDetails";

    public OrderDetailsService()
    {
        
    }
    
    public async Task<Response<List<OrderDetailsDto>>> GetAllAsync()
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<OrderDetailsDto>>>(json);
        return response;
    }

    public async Task<Response<OrderDetailsDto>> GetById(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<OrderDetailsDto>>(json);

        return response;    
    }

    public async Task<Response<OrderDetailsDto>> SaveAsync(OrderDetailsDto OrderDetails)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(OrderDetails);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<OrderDetailsDto>>(json);

        return response;    
    }

    public async Task<Response<OrderDetailsDto>> UpdateAsync(OrderDetailsDto OrderDetails)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(OrderDetails);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<OrderDetailsDto>>(json);

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