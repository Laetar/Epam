using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsArr;
            List<Word> wordList;

            Console.WriteLine("Введите распознаваемую строку");
            string str = Console.ReadLine();
            Console.WriteLine();

            wordsArr = SplitStr(str);
            wordList = WordList(wordsArr);
            WriteWordList(wordList);
            Console.ReadKey();
        }

        static private string[] SplitStr(string str)
        {
            int i;
            char[] separator = { ' ', ',', '.' };
            string[] wordsArr = str.Split(separator);
            wordsArr = wordsArr.Where(x => x != "").ToArray();
            for (i = 0; i < wordsArr.Length; i++)
            {
                wordsArr[i] = wordsArr[i].ToLower();
            }
            return wordsArr;
        }

        static private List<Word> WordList(string[] WordsArr)
        {
            bool FindWord;
            int i;
            List<Word> wordList = new List<Word>();

            for (i = 0; i < WordsArr.Length; i++)
            {
                FindWord = false;
                foreach (Word elem in wordList)
                {
                    if (elem.text == WordsArr[i])
                    {
                        FindWord = true;
                        elem.value++;
                    }
                }
                if (!FindWord) wordList.Add(new Word(WordsArr[i]));
            }
            return wordList;
        }

        static private void WriteWordList (List<Word> wordList)
        {
            foreach (Word elem in wordList)
            {
                Console.WriteLine(elem.text + ": {0}", elem.value);
            }
        }
    }
}
