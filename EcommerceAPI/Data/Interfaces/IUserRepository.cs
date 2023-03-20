using EcommerceAPI.DTO.User;
using EcommerceAPI.Entities;

namespace EcommerceAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(Guid UserId);
        void Post(CreateUserDTO user);
    }
}
