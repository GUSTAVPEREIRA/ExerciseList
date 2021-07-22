using ExerciseList.DTO.Cart;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;

namespace ExerciseList.Service.IService
{
    public interface ICartService
    {
        bool OpenCart(UserDTO user);
        void AddItem(ProductDTO productDTO, int quantity);
        bool RemoveItem(ProductDTO productDTO, int quantity);
        CartDTO GetCart();
    }
}