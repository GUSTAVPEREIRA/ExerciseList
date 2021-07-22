using System;
using ExerciseList.Service.IService;
using ExerciseList.Service.Service;

namespace ExerciseList.Exercise2
{
    public class Program
    {
        static void Main(string[] args)
        {
            IHappyNumberService serivce = new HappyNumberService();

            int number = 11;
            var isHappy = serivce.IsHappyNumber(number);
            string message = isHappy ? "é um número feliz" : "não é um número feliz";


            Console.WriteLine($"Número {number} {message}");
        }
    }
}