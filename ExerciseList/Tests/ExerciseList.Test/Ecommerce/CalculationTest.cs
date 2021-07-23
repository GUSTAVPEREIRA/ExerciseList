using ExerciseList.DTO.Cart;
using ExerciseList.DTO.Enum;
using ExerciseList.DTO.Product;
using ExerciseList.DTO.User;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Moq;
using Xunit;

namespace ExerciseList.Test.Ecommerce
{
    public class CalculationTest
    {
        private CalculationService calculationService;

        [Theory]
        [InlineData(EnumCep.MaringaJC, 20.50, 0, 1, 20.50)]
        [InlineData(EnumCep.PresidentePrudente, 30.50, 0, 1, 30.5)]
        [InlineData(EnumCep.Tarabai, 50.50, 60.50, 1, 111)]
        [InlineData(EnumCep.Tarabai, 50.50, 100.5, 1, 100.5)]
        public void MustCalculateCorrectly(EnumCep cep, decimal value, decimal valueProduct, int quantity, decimal expected)
        {
            //Given
            var correiosMock = new Mock<ICorreiosService>();

            calculationService = new CalculationService(correiosMock.Object);
            correiosMock.Setup(x => x.ShippingValue(It.IsAny<EnumCep>())).Returns(value);

            var cartDTO = new CartDTO(new UserDTO(1, "userTest", cep));
            var product = new ProductDTO(1, "productTest", valueProduct);
            var cartItem = new CartItemDTO(product, quantity);            

            //When
            cartDTO.CartItems.Add(cartItem);
            var result = calculationService.GetTotal(cartDTO);

            //Then
            Assert.Equal(expected, result);
        }
    }
}