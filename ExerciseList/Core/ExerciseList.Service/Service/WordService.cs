using System.Linq;
using System.Collections.Generic;
using ExerciseList.Service.IService;

namespace ExerciseList.Service.Service
{
    public class WordService : IWordService
    {
        private Dictionary<char, int> LetterList { get; set; }

        public WordService()
        {
            LetterList = CreateListOfLettersValue();
        }

        public int ConvertWordToNumber(string word)
        {
            int number = 0;

            foreach (var letter in word)
            {
                if (LetterList.ContainsKey(letter))
                {
                    number += LetterList[letter];
                }
            }

            return number;
        }

        private Dictionary<char, int> CreateListOfLettersValue()
        {
            LetterList = new Dictionary<char, int>();
            var letters = Enumerable.Range('a', 26).Select(x => (char)x).ToList();
            int lowerCase = 1;

            foreach (var letter in letters)
            {
                LetterList.Add(letter, lowerCase);
                var upperCaseLetter = char.Parse(letter.ToString().ToUpper());
                LetterList.Add(upperCaseLetter, lowerCase + 26);

                lowerCase++;
            }

            return LetterList;
        }
    }
}