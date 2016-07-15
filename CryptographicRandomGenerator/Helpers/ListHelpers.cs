using System.Collections.Generic;
using CryptographicRandomGenerator.Factories;

namespace CryptographicRandomGenerator.Helpers
{
    public static class ListHelpers
    {
        /// <summary>
        /// Method Satifies Assignment by returning a shuffled list of the integers from 1 to 10 000
        /// Knuth Fisher Yates Shuffle is used, CryptographicRandomGenerator.Factories.UintFactory supplies random values
        /// </summary>
        /// <returns>Shuffled List<int> of integers 1 to 10 000</returns>
        public static List<int> AssignmentMethod()
        {

            return null;
        }
        /// <summary>
        /// Applies Knuth Fischer Yates Shuffle to a list
        /// </summary>
        /// <typeparam name="T">Type Of list, logically irrelevant</typeparam>
        /// <param name="list">List of T to be shuffled</param>
        public static void ShuffleULong<T>(List<T> list)
        {
            var x = new ULongFactory();
            for (var index = 0; index < list.Count - 1; index++)
            {
                var newIndex = (int)(x.Next()%(ulong)(index - list.Count))+index;
                var placeHolder = list[index];
                list[index] = list[newIndex];
                list[newIndex] = placeHolder;
            }
        }
        /// <summary>
        /// Applies Knuth Fischer Yates Shuffle to a list
        /// </summary>
        /// <typeparam name="T">Type Of list, logically irrelevant</typeparam>
        /// <param name="list">List of T to be shuffled</param>
        public static void ShuffleUint<T>(List<T> list)
        {
            var x = new UIntFactory();
            for (var index = 0; index < list.Count - 1; index++)
            {
                var newIndex = (int)(x.Next() % (uint)(index - list.Count)) + index;
                var placeHolder = list[index];
                list[index] = list[newIndex];
                list[newIndex] = placeHolder;
            }
        }
        /// <summary>
        /// Included as sample of another possible helper method to justify class
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="Set">refrence to set for subset to be taken from</param>
        /// <param name="choose">number of items to be chosen for subset</param>
        /// <returns>list of type 'T' containing 'choose' items from 'Set'</returns>
        public static List<T> ChooseSubset<T>(List<T> Set, int choose)
        {
            var random = new ULongFactory();
            var chosen = new List<T>();
            for (var index = 0; index < choose; index++)
            {
                var num = (int)(random.Next()%(ulong)Set.Count);
                chosen.Add(Set[num]);
                Set.Remove(Set[num]);
            }
            return chosen;
        }
    }
}
