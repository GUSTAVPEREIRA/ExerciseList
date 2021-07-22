using System;
using System.Text;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;
using ExerciseList.Service.IService;

namespace ExerciseList.Exercise4.Controller
{
    public class CartController
    {
        private readonly ICartService CartService;
        private readonly ICalculationService CalculationService;

        public CartController(ICartService cartService, ICalculationService calculationService)
        {
            CartService = cartService;
            CalculationService = calculationService;
        }

        public void AddItem(ProductDTO productDTO, int quantity) 
        {            
            CartService.AddItem(productDTO, quantity);
        }

        public bool RemoveItem(ProductDTO productDTO, int quantity)
        {
            return CartService.RemoveItem(productDTO, quantity);
        }

        public void OpenCart(UserDTO userDTO) 
        {
            CartService.OpenCart(userDTO);            
        }

        public string GetReportShip() 
        {
            var cart = CartService.GetCart();
            var total = CalculationService.GetTotal(cart);

            StringBuilder report = new StringBuilder();

            report.Append($"\n{DateTime.UtcNow:dd/mm/yyy hh:mm}\t {"Produto".PadRight(70)} {"Quantitdade".PadRight(4)} Valor");

            foreach (var item in cart.CartItems)
            {
                report.Append($"\n\t\t\t {item.Product.Name.PadRight(70)} {item.Quantity.ToString().PadLeft(6).PadRight(11)} {item.GetTotalPrice():C2}");
            }


            report.Append($"\nValor Total:{total}");
            return report.ToString();
        }
    }
}