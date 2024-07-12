using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUser();
        Task<UserDto> GetById(int id);
        Task<int> AddUserAsync(UserDto userDto);
        Task<bool> UpdateAsync(UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
