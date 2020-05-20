using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "map_mesh", menuName = "Data/Map mesh")]
    public class MapMeshData : ScriptableObject {
        public GameObject baseBlock;
    }
}