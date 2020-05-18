using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelGenerator.Data {
    [CreateAssetMenu(fileName = "level_object_list", menuName = "Data/Level Generator/Level object list")]
    public class LevelObjectList : ScriptableObject {
        public GameObject baseBlock;
    }
}