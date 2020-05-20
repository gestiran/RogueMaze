using UnityEngine;

namespace Structures {
    public struct IntCoord {
        public int x;
        public int y;

        public IntCoord(int x, int y) {
            this.x = x;
            this.y = y;
        }

        /// <summary> Преобразовать в Vecor3 </summary>
        public Vector3 ToVector3() => new Vector3(x, 0, y);

        public override string ToString() => "X = " + x + "; Y = " + y + ";";
    }
}