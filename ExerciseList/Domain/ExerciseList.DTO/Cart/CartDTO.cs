using System.Linq;
using System.Collections.Generic;
using ExerciseList.DTO.User;
using ExerciseList.DTO.Product;

namespace ExerciseList.DTO.Cart
{
    public class CartDTO
    {
        public UserDTO User { get; private set; }
        public List<CartItemDTO> CartItems { get; set; }
        public decimal DeliveryValue { get; set; }

        public CartDTO(UserDTO user)
        {
            User = user;
            CartItems = new List<CartItemDTO>();
        }

        public decimal GetTotalCart()
        {
            return CartItems.Sum(s => s.GetTotalPrice()) + DeliveryValue;
        }
    }
}