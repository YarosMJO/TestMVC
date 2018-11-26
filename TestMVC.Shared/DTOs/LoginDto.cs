using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Shared.DTOs
{
    public class LoginDto
    {
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
