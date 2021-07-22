using ExerciseList.DTO.Cart;

namespace ExerciseList.Service.IService
{
    public interface ICalculationService
    {
        decimal GetTotal(CartDTO cartDTO);
    }
}