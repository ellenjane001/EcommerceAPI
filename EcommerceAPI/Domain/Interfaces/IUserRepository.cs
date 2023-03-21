using EcommerceAPI.Data.DTO.User;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid UserId);
        Task Post(CreateUserDTO user);
    }
}
