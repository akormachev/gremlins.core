using Gremlins.Core.Resources;
using System;

namespace Gremlins
{
    public static class RandomGenerator
    {
        private static readonly Random _random;

        /// <summary>
        /// Initialize <see cref="RandomGenerator"/>
        /// </summary>
        static RandomGenerator()
        {
            _random = new Random(Round.ToInt32(DateTime.UtcNow.Ticks % System.Int32.MaxValue));
        }

        /// <summary>
        /// Get random bool-value
        /// </summary>
        /// <returns>bool-value</returns>
        public static bool Boolean()
        {
            return _random.NextDouble() > 0.5;
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <returns>Value</returns>
        public static int Int32()
        {
            return _random.Next();
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <param name="maxValue">Maximum</param>
        /// <returns>Value</returns>
        public static int Int32(int maxValue)
        {
            return _random.Next(maxValue);
        }

        /// <summary>
        /// Get random int-value
        /// </summary>
        /// <param name="minValue">Minimum</param>
        /// <param name="maxValue">Maximum</param>
        /// <returns>Value</returns>
        public static int Int32(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue + 1);
        }

        /// <summary>
        /// Get random double-value
        /// </summary>
        /// <returns>Value</returns>
        public static double Double()
        {
            return _random.NextDouble();
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
            int index = _random.Next(items.Length);
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
            int index = _random.Next(items.Length);
            return items[index];
        }
    }
}
