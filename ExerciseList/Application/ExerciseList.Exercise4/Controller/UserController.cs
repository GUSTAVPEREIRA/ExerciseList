using ExerciseList.DTO.User;
using ExerciseList.Service.IService;

namespace ExerciseList.Exercise4.Controller
{
    public class UserController
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public UserDTO SignIn(string userName) 
        {
            var user = UserService.SignIn(userName);

            return user;
        }
    }
}