using TestMVC.Services;
using TestMVC.Shared.DTOs;

namespace TestMVC.BL.Services
{
    public class LoginService
    {
        private UserService userService;
        public LoginService(UserService userService)
        {
            this.userService = userService;
        }
        public bool CheckValidation(LoginDto loginDto)
        {
            var user = userService.GetAll().Find(x => x.UserName == loginDto.UserName);
            if (user != null && loginDto.Password == user.Password)
            {
                return true;
            }

            return false;
        }
    }
}
