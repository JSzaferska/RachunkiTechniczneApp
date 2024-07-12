using RachunkiTechniczneWebApi.DTOs.Admin;
using RachunkiTechniczneWebApi.Interfaces;
using RachunkiTechniczneWebApi.Models;

namespace RachunkiTechniczneWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            var allUsers = await _userRepository.GetAllAsync();
            var userList = new List<UserDto>();
            foreach (var user in allUsers)
            {
                var mapper = new UserDto()
                {
                    UserId = user.Id_user,
                    Owner = user.Owner,
                    Login = user.Login,
                    IsAdmin = user.Is_admin
                };
                userList.Add(mapper);
            }
            return userList;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var userModel = new UserDto()
            {
                Owner = user.Owner,
                Login = user.Login,
                Password = user.Password,
                IsAdmin = user.Is_admin
            };
            return userModel;
        }

        public async Task<int> AddUserAsync(UserDto userDto)
        {
            var userModel = new User
            {
                Owner = userDto.Owner,
                Login = userDto.Login,
                Password = userDto.Password,
                Is_admin = userDto.IsAdmin
            };
            return await _userRepository.AddUserAsync(userModel);
        }

        public async Task<bool> UpdateAsync(UserDto userDto)
        {
            var userModel = new User
            {
                Id_user = userDto.UserId,
                Owner = userDto.Owner,
                Password = userDto.Password,
                Is_admin = userDto.IsAdmin
            };
            return await _userRepository.UpdateAsync(userModel);
        }
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
