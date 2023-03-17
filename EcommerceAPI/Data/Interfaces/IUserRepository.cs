using EcommerceAPI.DTO.User;
using EcommerceAPI.Entities;

namespace EcommerceAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUser(Guid UserId);
        void Post(CreateUserDTO user);
    }
}
