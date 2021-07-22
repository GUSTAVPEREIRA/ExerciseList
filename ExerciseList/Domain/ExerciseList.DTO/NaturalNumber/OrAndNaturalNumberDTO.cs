namespace ExerciseList.DTO.NaturalNumber
{
    public class OrAndNaturalNumberDTO : BaseNaturalNumberDTO
    {
        public int Number3 { get; set; }

        public OrAndNaturalNumberDTO(int number1, int number2, int number3) : base(number1, number2)
        {
            Number3 = number3;
        }

        public override int IsMultiplierNumber(int value)
        {
            return (value % Number1 == 0 || value % Number2 == 0) && value % Number3 == 0 ? value : 0;
        }
    }
}