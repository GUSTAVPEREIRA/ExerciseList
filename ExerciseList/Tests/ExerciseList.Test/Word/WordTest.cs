using ExerciseList.Service.IService;
using ExerciseList.Service.Service;
using Xunit;

namespace ExerciseList.Test.Word
{
    public class WordTest
    {
        private IWordService service { get; set; }

        public WordTest()
        {
            service = new WordService();
        }

        [Theory]
        [InlineData("Objective", 117)]
        [InlineData("Solution", 151)]
        [InlineData("Objective Solutions", 287)]
        [InlineData("The only way to go fast is to go well", 414)]
        public void WordConvertValue(string word, int value)
        {
            //Given            
            service = new WordService();

            //When
            var result = service.ConvertWordToNumber(word);

            //Then
            Assert.Equal(value, result);
        }
    }
}