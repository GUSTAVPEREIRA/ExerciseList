using ExerciseList.DTO.Enum;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.Ecommerce
{
    public class CorreiosTest
    {

        public ICorreiosService correiosService;

        [Theory]
        [InlineData(EnumCep.MaringaJC, 20.50)]
        [InlineData(EnumCep.PresidentePrudente, 30.50)]
        [InlineData(EnumCep.Tarabai, 50.50)]
        public void TestName(EnumCep cep, decimal deliveryValue)
        {
            //Given
            correiosService = new CorreiosService();

            //When
            var result = correiosService.ShippingValue(cep);

            //Then
            Assert.Equal(deliveryValue, result);
        }
    }
}