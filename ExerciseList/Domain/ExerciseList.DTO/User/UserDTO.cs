using ExerciseList.DTO.Enum;

namespace ExerciseList.DTO.User
{
    public class UserDTO
    {
        public UserDTO(int id, string name, EnumCep cep)
        {
            Id = id;
            Name = name;
            Cep = cep;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }    
        public EnumCep Cep { get; set; }        
    }
}