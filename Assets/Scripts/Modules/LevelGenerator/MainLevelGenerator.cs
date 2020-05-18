using System.Collections;
using System.Collections.Generic;
using Structures;
using Modules.LevelGenerator.Data;
using UnityEngine;

namespace Modules.LevelGenerator {
    /// <summary> Генерация и заполнение уровня </summary>
    public class MainLevelGenerator : BaseModule {
        private Transform _levelparent;
        private LevelGenerateParams _params;
        private LevelObjectList _objects;
        
        public override void Init() {
            _levelparent = GameObject.FindGameObjectWithTag("Level").transform;
            _params = Resources.Load<LevelGenerateParams>("Data/LevelGenerator/level_001");
            _objects = Resources.Load<LevelObjectList>("Data/LevelGenerator/level_object_list");

            FillMap();
        }

        private void FillMap() {
            IntCoord spawnCoord;
            for (int xCoord = 0; xCoord < _params.mapHeigth; xCoord++) {
                for (int zCoord = 0; zCoord < _params.mapWidth; zCoord++) {
                    spawnCoord = new IntCoord(xCoord, zCoord);
                    GameObject.Instantiate(_objects.baseBlock, spawnCoord.ToVector3(),Quaternion.identity, _levelparent);
                }
            }
        }
    }
}