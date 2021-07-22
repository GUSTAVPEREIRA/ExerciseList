using System;
using ExerciseList.DTO.NaturalNumber;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;

namespace ExerciseList.Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            IWordService wordService = new WordService();
            IHappyNumberService happyNumberService = new HappyNumberService();
            INaturalNumberService naturalNumberService = new NaturalNumberService();
            OrNaturalNumberDTO dto = new OrNaturalNumberDTO(3, 5);

            string word = "Objective Solutions";
            var wordValue = wordService.ConvertWordToNumber(word);

            var isTrue = happyNumberService.IsHappyNumber(wordValue);            
            Console.WriteLine($"palavra {word} com valor de {wordValue} {ReturnMessage(isTrue)} é um número feliz!");

            isTrue = dto.IsMultiplierNumber(wordValue) == 0 ? false : true;
            Console.WriteLine($"palavra {word} com valor de {wordValue} {ReturnMessage(isTrue)} é multipla de 3 ou 5!");

            isTrue = naturalNumberService.isPrimeNumber(wordValue);            
            Console.WriteLine($"palavra {word} com valor de {wordValue} {ReturnMessage(isTrue)} é um número primo!");
        }

        private static string ReturnMessage(bool isTrue)
        {
            return isTrue ? "" : "não";
        }
    }
}