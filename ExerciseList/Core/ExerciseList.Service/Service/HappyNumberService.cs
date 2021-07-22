using System;
using System.Collections.Generic;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class HappyNumberService : IHappyNumberService
    {
        public bool IsHappyNumber(int number)
        {
            bool isHappy = true;
            IDictionary<int, int> numberList = new Dictionary<int, int>();

            do
            {
                var characterSum = SumPowerTo2(number);

                if (numberList.ContainsKey(characterSum))
                {
                    isHappy = false;
                }
                else
                {
                    numberList.Add(characterSum, number);
                    number = characterSum;
                }

            } while (isHappy && number != 1);

            return isHappy;
        }

        private int SumPowerTo2(int number)
        {
            int sum = 0;

            foreach (var item in number.ToString())
            {
                var itemValue = int.Parse(item.ToString());
                sum += itemValue * itemValue;
            }

            return sum;
        }
    }
}