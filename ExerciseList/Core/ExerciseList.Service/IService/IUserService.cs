using ExerciseList.DTO.User;

namespace ExerciseList.Service.IService
{
    public interface IUserService
    {
        UserDTO SignIn(string name);
    }
}