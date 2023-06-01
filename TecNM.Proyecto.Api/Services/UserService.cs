using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _UserRepository;

    public UserService(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    public async Task<UserDto> SaveAsync(UserDto UserDto)
    {
       var User = new User
       {   
            Name = UserDto.Name,
            Phone = UserDto.Phone,
            Username = UserDto.Username,   
            Password = UserDto.Password,
            Address = UserDto.Address,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        User = await _UserRepository.SaveAsync(User);
        UserDto.Id = User.Id;
        return UserDto;
    }

    public async Task<UserDto> UpdateAsync(UserDto UserDto)
    {
        var User = await _UserRepository.GetById(UserDto.Id);
        if (User == null)
            throw new Exception("User Not Found");
        User.Name = UserDto.Name;
        User.Phone = UserDto.Phone;
        User.Username = UserDto.Username;
        User.Address = UserDto.Address;
        User.UpdatedBy = "";
        User.UpdateDate = DateTime.Now;
        await _UserRepository.UpdateAsync(User);

        return UserDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var categories = await _UserRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new UserDto(c)).ToList();
        return categoriesDto;
    }

    public async Task<bool> UserExist(int id)
    {
        var User = await _UserRepository.GetById(id);
        return (User != null);
    }

    public  async Task<bool> UserNameExist(string username)
    {
        var user = await _UserRepository.GetByUserName(username);
        return (user != null);
    }

    public async Task<UserDto> GetById(int id)
    {
        var User = await _UserRepository.GetById(id);
        if (User == null)
            throw new Exception("Product User Not Found");
        var UserDto = new UserDto(User);
        return UserDto;
    }

    public async Task<UserDto> GetByUserName(string username)
    {
        var User = await _UserRepository.GetByUserName(username);
        if (User == null)
            throw new Exception("User Not Found");
    
        var UserDto = new UserDto(User);
        return UserDto;

    }

    public async Task<bool> DeleteAsync(int id)
    {
         return await _UserRepository.DeleteAsync(id);
        
    }
}