using Newtonsoft.Json;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Services;

public class UserService : IUserService
{
    private readonly string _baseurl = "https://localhost:7033/";
    private readonly string _endpoint = "api/User";

    public UserService()
    {
    }

    public async Task<Response<List<UserDto>>> GetAllAsync()
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<UserDto>>>(json);
        return response;
    }

    public async Task<Response<UserDto>> GetById(int id)
    {
        var url = $"{_baseurl}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);
        Console.WriteLine(response.Data);
        return response;
    }
    public async Task<Response<UserDto>> SaveAsync(UserDto User)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(User);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8,
            "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);
        return response;
    }

    public async Task<Response<UserDto>> UpdateAsync(UserDto User)
    {
        var url = $"{_baseurl}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(User);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

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

    public async Task<Response<UserDto>> GetByUserName(string username)
    {
        var url = $"{_baseurl}{_endpoint}/{username}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<UserDto>>(json);

        return response;
    }

    public async Task<Response<UserDto>> LoginAsync(string username, string password)
    {
        var url = $"{_baseurl}{_endpoint}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<List<UserDto>>>(json);
        foreach (var user in response.Data)
        {
            if (user.Username == username & user.Password ==password) 
            {
                return new Response<UserDto>
                {
                    Success = true,
                    Data = user
                };
            }
        }
        return new Response<UserDto>
        {
            Success = false,
            Data = null
        };
    }
}