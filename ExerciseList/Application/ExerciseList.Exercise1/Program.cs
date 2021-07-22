using System;
using ExerciseList.DTO.NaturalNumber;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;

namespace ExerciseList.Exercise1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INaturalNumberService service = new NaturalNumberService();

            var result = service.SumMultiplierNumber(new OrNaturalNumberDTO(3, 5));
            Console.WriteLine($"O valor da soma de todos os números múltiplos de 3 ou 5 é {result}");
            
            result= service.SumMultiplierNumber(new AndNaturalNumberDTO(3, 5));
            Console.WriteLine($"O valor da soma de todos os números múltiplos de 3 e 5 é {result}");

            result = service.SumMultiplierNumber(new OrAndNaturalNumberDTO(3, 5, 7));
            Console.WriteLine($"O valor da soma de todos os números múltiplos de 3 ou 5 e 7 é {result}");            
        }
    }
}