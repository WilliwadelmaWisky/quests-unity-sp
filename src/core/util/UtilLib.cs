using System;
using System.Collections.Generic;

namespace WWWisky.quests.core
{
    /// <summary>
    /// 
    /// </summary>
    public static class UtilLib
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> query, Action<T, int> action)
        {
            int index = 0;
            foreach (T item in query)
            {
                action(item, index);
                index++;
            }
        }
    }
}
