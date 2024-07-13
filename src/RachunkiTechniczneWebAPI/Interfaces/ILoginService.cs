using RachunkiTechniczneWebApi.DTOs;
using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Interfaces
{
    public interface ILoginService
    {
        Task<LoggedUserDto> Login(LoginDto userLogin);
    }
}
