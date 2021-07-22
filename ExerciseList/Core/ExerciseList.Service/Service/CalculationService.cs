using ExerciseList.DTO.Cart;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class CalculationService : ICalculationService
    {
        private readonly ICorreiosService CorreiosSerivce;

        public CalculationService(ICorreiosService correiosSerivce)
        {
            CorreiosSerivce = correiosSerivce;
        }

        public decimal GetTotal(CartDTO cartDTO)
        {
            var deliveryValue = CorreiosSerivce.ShippingValue(cartDTO.User.Cep);

            return cartDTO.GetTotalCart() + deliveryValue;
        }
    }
}