using Gremlins.Core.Resources;
using System;
using System.Threading;

namespace Gremlins
{
    public static class RandomGenerator
    {

        #region Fields

        private static int _seed = Environment.TickCount;

        private static ThreadLocal<Random> _randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref _seed))
        );

        #endregion

        #region Public methods

        public static Random GetThreadRandom()
        {
            return _randomWrapper.Value;
        }

        /// <summary>
        /// Get random bool-value
        /// </summary>
        /// <returns>bool-value</returns>
        public static bool Boolean()
        {
            return _randomWrapper.Value.NextDouble() > 0.5;
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <returns>Value</returns>
        public static int Int32()
        {
            return _randomWrapper.Value.Next();
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <param name="maxValue">Maximum</param>
        /// <returns>Value</returns>
        public static int Int32(int maxValue)
        {
            return _randomWrapper.Value.Next(maxValue);
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <param name="minValue">Minimum</param>
        /// <param name="maxValue">Maximum</param>
        /// <returns>Value</returns>
        public static int Int32(int minValue, int maxValue)
        {
            return _randomWrapper.Value.Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// Get random double-value
        /// </summary>
        /// <returns>Value</returns>
        public static double Double()
        {
            return _randomWrapper.Value.NextDouble();
        }

        /// <summary>
        /// Get random item from array
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="items">Array</param>
        /// <returns>Picked item</returns>
        public static T One<T>(T[] items)
        {
            if (items.Length == 0)
                throw new InvalidOperationException(Errors.SourceCollectionIsEmpty);
            int index = _randomWrapper.Value.Next(items.Length);
            return items[index];
        }

        /// <summary>
        /// Get random item from array
        /// </summary>
        /// <typeparam name="T">Type of item</typeparam>
        /// <param name="items">Array</param>
        /// <returns>Picked item</returns>
        public static T OneOrDefault<T>(T[] items)
        {
            if (items.Length == 0)
                return default(T);
            int index = _randomWrapper.Value.Next(items.Length);
            return items[index];
        }

        #endregion
    }
}
