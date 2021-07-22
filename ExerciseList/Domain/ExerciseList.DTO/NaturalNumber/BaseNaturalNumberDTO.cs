namespace ExerciseList.DTO.NaturalNumber
{
    public abstract class BaseNaturalNumberDTO
    {
        public BaseNaturalNumberDTO(int number1, int number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public virtual int IsMultiplierNumber(int value)
        {
            return value % Number1  == 0 && value % Number2 == 0 ? value : 0;
        }
    }
}