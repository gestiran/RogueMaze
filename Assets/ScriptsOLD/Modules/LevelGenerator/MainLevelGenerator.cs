using System.Collections;
using System.Collections.Generic;
using Data;
using Structures;
using UnityEngine;

namespace Modules.LevelGenerator {
    [CreateAssetMenu(fileName = "level_generator", menuName = "Modules/Level generator")]
    public class MLevelGenerator : BaseModule {
        public MapMeshData meshData;

        public int mapWidth;
        public int mapHeigth;

        private Transform _levelparent;
        private IntCoord[,] _mapCoord;
        private IntCoord _thisCoord;
        
        #region INIT

        public override void Init() {
            _levelparent = GameObject.FindGameObjectWithTag("Level").transform;
            _mapCoord = new IntCoord[mapHeigth, mapWidth];
            if (meshData != null) GenerateMap();
        }

        public override void Destroy() => isEnable = false;

        #endregion

        #region METHODS

        private void GenerateMap() {

        }

        #endregion
    }
}