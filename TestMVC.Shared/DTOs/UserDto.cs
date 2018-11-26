using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required,MinLength(5)]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
