using UnityEngine;

namespace Structures {
    public struct mapCoord {
        public ushort x;
        public ushort y;

        public mapCoord(int x, int y) {
            this.x = (ushort)x;
            this.y = (ushort)y;
        }

        public mapCoord(ushort x, ushort y) {
            this.x = x;
            this.y = y;
        }

        /// <summary> Преобразовать в Vecor3 </summary>
        public Vector3 ToVector3() => new Vector3(x, 0, y);

        public override string ToString() => "X = " + x + "; Y = " + y + ";";
    }
}