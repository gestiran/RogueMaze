using UnityEngine;

namespace Structures {
    /// <summary> Координаты для генерации карты y = z</summary>
    public struct mapCoord {
        public ushort x;
        public ushort y;
        public ushort z;

        public mapCoord(int x, int y, int z = 0) {
            this.x = (ushort)x;
            this.y = (ushort)y;
            this.z = (ushort)z;
        }

        public mapCoord(ushort x, ushort y, ushort z = 0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary> Преобразовать в Vecor3 </summary>
        public Vector3 ToVector3() => new Vector3(x, z, y);

        public override string ToString() => "X = " + x + "; Y = " + y + "; Z = " + z + ";";
    }
}