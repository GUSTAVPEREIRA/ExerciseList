using System.Linq;
using ExerciseList.DTO.Cart;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class CartService : ICartService
    {
        private CartDTO CartDTO { get; set; }

        public CartService()
        {
            CartDTO = null;
        }

        public bool OpenCart(UserDTO user)
        {
            bool cartOpen = false;

            if (user != null)
            {
                CartDTO = new CartDTO(user);
                cartOpen = true;
            }

            return cartOpen;
        }

        public void AddItem(ProductDTO productDTO, int quantity)
        {
            if (CartDTO != null && quantity > 0 && productDTO != null)
            {
                CartItemDTO item = new CartItemDTO(productDTO, quantity);
                var cartItem = CartDTO.CartItems.Where(w => w.Product.Id == productDTO.Id).FirstOrDefault();

                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    CartDTO.CartItems.Add(item);
                }
            }
        }

        public bool RemoveItem(ProductDTO productDTO, int quantity)
        {
            bool isRemoved = false;

            if (CartDTO != null && quantity > 0)
            {
                var cartItem = CartDTO.CartItems.Where(w => w.Product.Id == productDTO.Id).FirstOrDefault();

                if (cartItem != null)
                {
                    cartItem.Quantity -= quantity;

                    if (cartItem.Quantity <= 0)
                    {
                        CartDTO.CartItems.Remove(cartItem);
                    }
                }

            }

            return isRemoved;
        }

        public CartDTO GetCart()
        {
            return CartDTO;
        }
    }
}