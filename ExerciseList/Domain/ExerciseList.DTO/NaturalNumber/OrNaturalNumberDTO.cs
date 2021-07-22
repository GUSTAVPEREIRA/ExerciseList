namespace ExerciseList.DTO.NaturalNumber
{
    public class OrNaturalNumberDTO : BaseNaturalNumberDTO
    {
        public OrNaturalNumberDTO(int number1, int number2) : base(number1, number2)
        {

        }

        public override int IsMultiplierNumber(int value)
        {
            return value % Number1 == 0 || value % Number2 == 0 ? value : 0;
        }
    }
}