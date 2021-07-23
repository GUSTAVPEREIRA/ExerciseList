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
            var totalCart = cartDTO.GetTotalCart();

            if(totalCart < 100) 
            {
                totalCart += CorreiosSerivce.ShippingValue(cartDTO.User.Cep);
            }

            return totalCart;
        }
    }
}