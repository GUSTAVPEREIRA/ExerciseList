using ExerciseList.DTO.Enum;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class CorreiosService : ICorreiosService
    {
        public decimal ShippingValue(EnumCep cep)
        {
            decimal value = 0m;

            switch (cep)
            {
                case EnumCep.MaringaJC:
                    value = 20.50m;
                    break;
                case EnumCep.PresidentePrudente:
                    value = 30.50m;
                    break;
                case EnumCep.Tarabai:
                    value = 50.50m;
                    break;
            }

            return value;
        }
    }
}