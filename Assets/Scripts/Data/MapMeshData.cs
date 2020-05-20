using UnityEngine;

namespace Data {
    /// <summary> Массив GameObject </summary>
    [CreateAssetMenu(fileName = "map_mesh", menuName = "Data/Map mesh")]
    public class MapMeshData : ScriptableObject {
        public GameObject[] meshObjects;
    }
}