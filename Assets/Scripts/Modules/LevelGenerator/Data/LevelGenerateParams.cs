using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelGenerator.Data {
    [CreateAssetMenu(fileName = "level_generate_params", menuName = "Data/Level Generator/Level generate params")]
    public class LevelGenerateParams : ScriptableObject {
        public int mapWidth;
        public int mapHeigth;
    }
}