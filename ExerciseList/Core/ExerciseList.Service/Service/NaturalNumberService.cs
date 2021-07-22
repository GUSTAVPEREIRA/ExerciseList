using ExerciseList.DTO.NaturalNumber;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class NaturalNumberService : INaturalNumberService
    {
        public bool isPrimeNumber(int number)
        {
            bool isPrimeNumber = true;
            isPrimeNumber = (number % 2 != 0 || number == 2) && number > 1;            

            for (int i = 3; i < number && isPrimeNumber != false; i = i + 2)
            {
                isPrimeNumber = number % i != 0;
            }

            return isPrimeNumber;
        }

        public int SumMultiplierNumber(BaseNaturalNumberDTO dto)
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                sum += dto.IsMultiplierNumber(i);
            }

            return sum;
        }
    }
}