using ExerciseList.DTO.NaturalNumber;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.NaturalNumber
{
    public class NaturalNumberTest
    {
        private INaturalNumberService service { get; set; }

        [Theory]
        [InlineData(3, 5, 33165)]
        [InlineData(3, 9, 55944)]
        [InlineData(3, 4, 41832)]
        public void Number1AndNumber2EqualsValue(int number1, int number2, int value)
        {
            //Given
            var dto = new AndNaturalNumberDTO(number1, number2);
            service = new NaturalNumberService();

            //When
            var result = service.SumMultiplierNumber(dto);

            //Then
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(3, 5, 233168)]
        [InlineData(3, 7, 214216)]
        [InlineData(3, 6, 166833)]
        public void Number1OrNumber2EqualsValue(int number1, int number2, int value)
        {
            //Given
            var dto = new OrNaturalNumberDTO(number1, number2);
            service = new NaturalNumberService();

            //When
            var result = service.SumMultiplierNumber(dto);

            //Then
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(3, 5, 7, 33173)]
        [InlineData(3, 7, 3, 166833)]
        [InlineData(3, 6, 4, 41832)]
        public void Number1OrNumber2AndNumber3EqualsValue(int number1, int number2, int number3, int value)
        {
            //Given
            var dto = new OrAndNaturalNumberDTO(number1, number2, number3);
            service = new NaturalNumberService();

            //When
            var result = service.SumMultiplierNumber(dto);

            //Then
            Assert.Equal(value, result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(11)]
        [InlineData(13)]
        public void NumberIsPrime(int number)
        {
            //Given            
            service = new NaturalNumberService();

            //When
            var result = service.isPrimeNumber(number);

            //Then
            Assert.True(result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(12)]
        public void NumberIsntPrime(int number)
        {
            //Given            
            service = new NaturalNumberService();

            //When
            var result = service.isPrimeNumber(number);

            //Then
            Assert.False(result);
        }
    }
}