using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.HappyNumber
{
    public class HappyNumberTest
    {
        private IHappyNumberService service { get; set; }

        [Theory]
        [InlineData(7)]
        [InlineData(49)]
        [InlineData(97)]
        [InlineData(130)]
        [InlineData(10)]
        [InlineData(1)]
        public void NumberIsHappy(int number)
        {
            //Given
            service = new HappyNumberService();

            //When
            bool isHappy = service.IsHappyNumber(number);

            //Then
            Assert.True(isHappy);
        }

        [Theory]
        [InlineData(8)]
        [InlineData(4)]
        [InlineData(2)]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(20)]
        public void NumberIsntHappy(int number)
        {
            //Given
            service = new HappyNumberService();
            
            //When
            bool isHappy = service.IsHappyNumber(number);

            //Then
            Assert.False(isHappy);

        }

    }
}