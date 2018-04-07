using System;
using System.Collections.Generic;
using System.Linq;
namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var IntList = new List<int> { 1, 2, 4, 1, 6, 1, 5, 8, 4, 3, 8, 4, 5, 7 };
            var StrList = new List<string> { "olo", "ololo", "olo", "ol", "oo", "ol" };

            FrequencyInt(IntList);
            Console.WriteLine();

            FrequencyCollection(StrList);
            Console.WriteLine();

            FrequencyCollection(IntList);
            Console.WriteLine();

            FrequencyWithLinq(IntList);
            OrderByWithLambdas();
            Console.ReadKey();
        }


        /// <summary>
        /// Частотный поиск для целых чисел;
        /// </summary>
        /// <param name="IntList"></param>
        static void FrequencyInt(List<int> IntList)
        {
            var tmp = new Dictionary<int, int>();

            foreach (var el in IntList)
            {
                if (tmp.TryGetValue(el, out int result))
                    tmp[el]++;
                else
                    tmp.Add(el, 1);
            }

            PrintDictionary(tmp);
        }

        /// <summary>
        /// Частотный поиск для обобщенной коллекции;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IntList"></param>
        static void FrequencyCollection<T>(List<T> IntList)
        {
            var tmp = new Dictionary<T, int>();

            foreach (var el in IntList)
            {
                if (tmp.TryGetValue(el, out int result))
                    tmp[el]++;
                else
                    tmp.Add(el, 1);
            }

            PrintDictionary(tmp);
        }

        /// <summary>
        /// Частотный поиск с использованием Linq.
        /// </summary>
        /// <param name="IntList"></param>
        static void FrequencyWithLinq(List<int> IntList)
        {
            Dictionary<int, int> tmp = IntList.GroupBy(el => el)
                .ToDictionary(el => el.Key, el => el.Count());

            PrintDictionary(tmp);
        }
        /// <summary>
        /// Метод для сортировки и вывода элементов Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        static void PrintDictionary<T>(Dictionary<T, int> dict)
        {
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);

        }

        /// <summary>
        /// OrderBy с использованием лямбда-выражения
        /// </summary>
        static void OrderByWithLambdas()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                {"one",1 },
                {"three",3 }
            };

            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }

}
