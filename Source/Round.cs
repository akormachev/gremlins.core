using System;

namespace Gremlins
{
    public static class Round
    {
        public static byte ToByte(double value)
        {
            if (value > byte.MaxValue)
                return byte.MaxValue;
            if (value < byte.MinValue)
                return byte.MinValue;
            return Convert.ToByte(System.Math.Floor(value));
        }

        public static short ToInt16(float value)
        {
            if (value > short.MaxValue)
                return short.MaxValue;
            if (value < short.MinValue)
                return short.MinValue;
            return Convert.ToInt16(value);
        }

        public static ushort ToUInt16(decimal value)
        {
            if (value > ushort.MaxValue)
                return ushort.MaxValue;
            if (value < ushort.MinValue)
                return ushort.MinValue;
            return Convert.ToUInt16(value);
        }

        public static ushort ToUInt16(double value)
        {
            if (value > ushort.MaxValue)
                return ushort.MaxValue;
            if (value < ushort.MinValue)
                return ushort.MinValue;
            return Convert.ToUInt16(value);
        }

        public static int ToInt32(float value)
        {
            if (value > int.MaxValue)
                return int.MaxValue;
            if (value < int.MinValue)
                return int.MinValue;
            return Convert.ToInt32(value);
        }

        public static int ToInt32(double value)
        {
            if (value > int.MaxValue)
                return int.MaxValue;
            if (value < int.MinValue)
                return int.MinValue;
            return Convert.ToInt32(value);
        }

        public static ushort ToUInt16(float value)
        {
            if (value > ushort.MaxValue)
                return ushort.MaxValue;
            if (value < ushort.MinValue)
                return ushort.MinValue;
            return Convert.ToUInt16(value);
        }

        public static ushort ToUInt16(int value)
        {
            if (value > ushort.MaxValue)
                return ushort.MaxValue;
            if (value < ushort.MinValue)
                return ushort.MinValue;
            return Convert.ToUInt16(value);
        }

        public static ushort ToUInt16(ulong value)
        {
            if (value > ushort.MaxValue)
                return ushort.MaxValue;
            if (value < ushort.MinValue)
                return ushort.MinValue;
            return Convert.ToUInt16(value);
        }

        public static uint ToUInt32(float value)
        {
            if (value > uint.MaxValue)
                return uint.MaxValue;
            if (value < uint.MinValue)
                return uint.MinValue;
            return Convert.ToUInt32(value);
        }

        public static uint ToUInt32(double value)
        {
            if (value > uint.MaxValue)
                return uint.MaxValue;
            if (value < uint.MinValue)
                return uint.MinValue;
            return Convert.ToUInt32(value);
        }

        public static ulong ToUInt64(float value)
        {
            if (value > ulong.MaxValue)
                return ulong.MaxValue;
            if (value < ulong.MinValue)
                return ulong.MinValue;
            return Convert.ToUInt32(value);
        }

        public static ulong ToUInt64(double value)
        {
            if (value > ulong.MaxValue)
                return ulong.MaxValue;
            if (value < ulong.MinValue)
                return ulong.MinValue;
            return Convert.ToUInt32(value);
        }
    }
}
