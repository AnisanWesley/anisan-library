using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
     public static class ListControlExtensions
    {
	    /// <summary>
        ///  Ovverride all items from list
        ///  Sobre-escreve todos os itens da lista 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listControl"></param>
        /// <param name="sourceList"></param>
        public static void OverrideAll<T>(this IList listControl, IEnumerable<T> sourceList)
        {
            listControl.Clear();

            foreach (T item in sourceList)
            {
                if (item != null)
                    listControl.Add(item);
            }
            
        }
    
        /// <summary>
        /// Returns 1 or N  number of random items from a generic list
        /// Retorna 1 ou N quantidade de itens de uma lista genérica
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="list"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IEnumerable<T> Randomize<T>(this List<T> list, int count)
        {
            List<T> randomList = new List<T>();
            Random random = new Random();

            while (list.Count > 0)
            {
                //get the next random number between 0 and
                //the list count
                int idx = random.Next(0, list.Count);

                //get that index
                randomList.Add(list[idx]);

                //remove that item so it cant be added again
                list.RemoveAt(idx);
            }

            //return the specified number of items
            return randomList.Take(count);
        }

        /// <summary>
        /// Returns 1 random item from the list
        /// Retorna 1 item aleatório da lista
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="list">Generic list we wish to retrieve from</param>
        /// <returns></returns>
        public static T Randomize<T>(this List<T> list)
        {
            return Randomize(list, 1).FirstOrDefault();
        }
		/// <summary>
		/// Returns true for empty list
		/// Informa se a lista está vazia
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <returns></returns>
        public static bool IsEmpty<T>(this List<T> list)
        {
            return list.Count == 0;
        } 
    }
}
