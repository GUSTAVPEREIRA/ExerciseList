using System;
using System.Linq;
using ExerciseList.DTO.Enum;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Moq;
using Xunit;

namespace ExerciseList.Test.Ecommerce
{
    public class CartTest
    {
        private ICartService cartService;

        public CartTest()
        {
            OpenCart();
        }

        [Fact]
        public void OpenCartCorrectly()
        {                    
            //Then
            Assert.NotNull(cartService.GetCart());
        }

        [Fact]
        public void MustAddCartItemCorrectly()
        {
            //Given            
            ProductDTO productDTO = new ProductDTO(1, "TestProduct", 10m);
            decimal totalExpected = 140;
            int itemsExpected = 1;

            //When
            cartService.AddItem(productDTO, 10);
            cartService.AddItem(productDTO, 1);
            cartService.AddItem(productDTO, 3);
            cartService.AddItem(productDTO, -4);

            //Then
            var cart = cartService.GetCart();
            Assert.Equal(itemsExpected, cart.CartItems.Count());
            Assert.Equal(totalExpected, cart.GetTotalCart());
        }

        private void OpenCart()
        {            
            UserDTO user = new UserDTO(1, "UserTest", EnumCep.PresidentePrudente);
            cartService = new CartService();
            cartService.OpenCart(user);
        }

        public void Dispose() 
        {
            cartService = null;
        }

        [Fact]        
        public void MustRemoveCartItemCorrectly()
        {
            //Given            
            ProductDTO productDTO = new ProductDTO(1, "TestProduct", 10m);
            decimal totalExpected = 100;
            int itemsExpected = 1;

            //When
            cartService.AddItem(productDTO, 10);
            cartService.AddItem(productDTO, 1);
            cartService.AddItem(productDTO, 3);
            cartService.RemoveItem(productDTO, -4);
            cartService.RemoveItem(productDTO, 4);

            //Then
            var cart = cartService.GetCart();
            Assert.Equal(itemsExpected, cart.CartItems.Count());
            Assert.Equal(totalExpected, cart.GetTotalCart());
        }

        [Fact]
        public void NotInsertItemWithClosedCart()
        {
            //Given                        
            cartService = new CartService();
            ProductDTO productDTO = new ProductDTO(1, "TestProduct", 10m);

            //When
            cartService.AddItem(productDTO, 10);

            //Then
            var cart = cartService.GetCart();
            Assert.Null(cart);
        }

        [Fact]
        public void MustRemoveAllCartItemCorrectly()
        {
            //Given            
            ProductDTO productDTO = new ProductDTO(1, "TestProduct", 10m);
            decimal totalExpected = 0;
            int itemsExpected = 0;

            //When
            cartService.AddItem(productDTO, 10);
            cartService.AddItem(productDTO, 1);
            cartService.AddItem(productDTO, 3);
            cartService.RemoveItem(productDTO, 14);            

            //Then
            var cart = cartService.GetCart();
            Assert.Equal(itemsExpected, cart.CartItems.Count());
            Assert.Equal(totalExpected, cart.GetTotalCart());
        }

    }
}