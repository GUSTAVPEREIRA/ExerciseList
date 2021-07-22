using ExerciseList.DTO.NaturalNumber;

namespace ExerciseList.Service.IService
{
    public interface INaturalNumberService
    {
        int SumMultiplierNumber(BaseNaturalNumberDTO dto);

        bool isPrimeNumber(int number);
    }
}