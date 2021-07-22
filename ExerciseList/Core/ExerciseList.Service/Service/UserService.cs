using System.Linq;
using System.Collections.Generic;
using ExerciseList.DTO.User;
using ExerciseList.Service.IService;
using ExerciseList.DTO.Enum;

namespace ExerciseList.Service.Service
{
    public class UserService : IUserService
    {
        private List<UserDTO> Users { get; set; }

        public UserService()
        {
            Initialize();
        }

        public UserDTO SignIn(string name)
        {
            var user = Users.Where(w => w.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
            return user;
        }


        private void Initialize()
        {
            Users = new List<UserDTO>();

            Users.Add(new UserDTO(1, "Gustavo", EnumCep.Tarabai));
            Users.Add(new UserDTO(2, "Gabriela", EnumCep.MaringaJC));
            Users.Add(new UserDTO(3, "Jose", EnumCep.PresidentePrudente));
        }
    }
}