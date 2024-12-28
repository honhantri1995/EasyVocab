using System;
using System.Collections.Generic;

namespace VocabManager
{
    public static class ListExtensions
    {
        private static Random _random = new Random();

        // Shuffle items in input list in random order
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
