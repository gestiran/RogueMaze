using System.Collections;
using System.Collections.Generic;
using Data;
using Structures;
using UnityEngine;

namespace Modules {
    [CreateAssetMenu(fileName = "level_generator", menuName = "Modules/Level generator")]
    public class MLevelGenerator : BaseModule {
        [SerializeField] private MapMeshData _meshData;
        [SerializeField] private int _mapHeigth;
        [SerializeField] private int _mapWidth;
        [SerializeField] private int _pathIterations;

        [SerializeField] [Range(0, 100)] private int _spawnRandomize = 50;

        private Transform _levelparent;
        private int[,] _mapCoord;
        private IntCoord _thisCoord;
        
        #region INIT

        public override void Init() {
            _levelparent = GameObject.FindGameObjectWithTag("Level").transform;
            _mapCoord = new int[_mapWidth, _mapHeigth];

            if (_meshData != null || _levelparent != null) GenerateMap();
        }

        public override void Destroy() => isEnable = false;

        #endregion

        #region METHODS

        private void GenerateMap() {
            IntCoord spawnCoord = FindCoordinate();
            IntCoord newSpawnCoord = spawnCoord;

            for (int iterate = 0, loopFix = 0; iterate < _pathIterations && loopFix < _pathIterations * 4; loopFix++) {
                newSpawnCoord = RandomiseCoord(newSpawnCoord);

                if (_mapCoord[newSpawnCoord.x, newSpawnCoord.y] == 0) {
                    GameObject newTile = _meshData.baseBlock;
                    _mapCoord[newSpawnCoord.x, newSpawnCoord.y] = 1;
                    spawnCoord = newSpawnCoord;

                    GameObject.Instantiate(newTile, spawnCoord.ToVector3(), newTile.transform.rotation, _levelparent);

                    iterate++;
                } else continue;
            }
        }

        private IntCoord RandomiseCoord(IntCoord coord) {
            if (coord.y < _mapHeigth - 1 && coord.y > 0 && Random.Range(0, 100) < _spawnRandomize) coord.y = (Random.Range(0, 100) < _spawnRandomize) ? coord.y + 1 : coord.y - 1;
            else if (coord.x < _mapWidth - 1 && coord.x > 0 && Random.Range(0, 100) < _spawnRandomize) coord.x = (Random.Range(0, 100) < _spawnRandomize) ? coord.x + 1 : coord.x - 1;
            else if (coord.x == 0 && _mapCoord[coord.x + 1, coord.y] == 0) coord.x++;
            else if (coord.x == _mapWidth - 1 && _mapCoord[coord.x - 1, coord.y] == 0) coord.x--;
            else if (coord.y == 0 && _mapCoord[coord.x, coord.y + 1] == 0) coord.y++;
            else if (coord.y == _mapHeigth - 1 && _mapCoord[coord.x, coord.y - 1] == 0) coord.y--;

            return coord;
        }

        private IntCoord FindCoordinate() => new IntCoord(Random.Range(_mapWidth / 4, _mapWidth / 2), Random.Range(_mapHeigth / 4, _mapHeigth / 2));

        #endregion
    }
}