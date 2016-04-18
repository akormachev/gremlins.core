using System.Collections.Generic;

namespace Gremlins.Comparers
{
    public class FloatComparer : IComparer<float>
    {

        #region Properties

        public float Epsilon { get; set; }

        #endregion

        #region IComparer<float> implementation

        public int Compare(float x, float y)
        {
            if (x > y + Epsilon)
                return 1;
            if (x < y - Epsilon)
                return -1;
            return 0;
        }

        #endregion

    }
}
