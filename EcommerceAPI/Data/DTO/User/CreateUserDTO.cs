using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Data.DTO.User
{
    public class CreateUserDTO
    {
        [Required]
        public string UserName { get; set; }
    }
}
