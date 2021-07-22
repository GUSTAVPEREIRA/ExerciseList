using ExerciseList.DTO.Product;

namespace ExerciseList.DTO.Cart
{
    public class CartItemDTO
    {
        public CartItemDTO(ProductDTO product, int quantity)
        {
            Product = product;            
            Quantity = quantity;
        }

        public ProductDTO Product { get; private set; }
        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}