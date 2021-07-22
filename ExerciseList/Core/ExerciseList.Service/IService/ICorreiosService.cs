using ExerciseList.DTO.Enum;

namespace ExerciseList.Service.IService
{
    public interface ICorreiosService
    {
        decimal ShippingValue(EnumCep cep);
    }
}