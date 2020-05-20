using System.Collections;
using System.Collections.Generic;
using Data;
using Structures;
using UnityEngine;

namespace Modules {
    /// <summary> Реализовывает случайную генерацию уровня по заданным параметрам </summary>
    [CreateAssetMenu(fileName = "level_generator", menuName = "Modules/Level generator")]
    public class MLevelGenerator : BaseModule {
        [SerializeField] private MapMeshData _meshData;
        [SerializeField] private ushort _mapHeigth;
        [SerializeField] private ushort _mapWidth;
        [SerializeField] private ushort _minLevels;
        private ushort _pathIterations;

        private Transform _levelparent;
        private ushort[,,] _mapCoord;
        
        private mapCoord _thisCoord;
        
        #region INIT

        public override void Init() {
            _levelparent = GameObject.FindGameObjectWithTag("Level").transform;
            _mapCoord = new ushort[_mapWidth, _mapHeigth, _minLevels];
            _pathIterations = (ushort)((_mapWidth + _mapHeigth) / 2);

            if (_meshData != null || _levelparent != null) GenerateMap();
        }

        public override void Destroy() => isEnable = false;

        #endregion

        #region METHODS

        /// <summary> Создание карты </summary>
        private void GenerateMap() {
            GenerateDownLayer();
            for (ushort zCoordLevel = 1; zCoordLevel < _minLevels; zCoordLevel++) GenerateUpLayer(zCoordLevel);
        }

        /// <summary> Генерация нижнего уровня </summary>
        private void GenerateDownLayer() {
            mapCoord spawnCoord = FindCoordinate();
            mapCoord newSpawnCoord = spawnCoord;

            for (ushort iterate = 0, loopFix = 0; iterate < _pathIterations && loopFix < _pathIterations * 4; loopFix++) {
                newSpawnCoord = RandomiseCoord(newSpawnCoord);

                if (_mapCoord[newSpawnCoord.x, newSpawnCoord.y, 0] == 0) {
                    GameObject newTile = _meshData.meshObjects[0];
                    _mapCoord[newSpawnCoord.x, newSpawnCoord.y, 0] = 1;
                    spawnCoord = newSpawnCoord;

                    GameObject.Instantiate(newTile, spawnCoord.ToVector3(), newTile.transform.rotation, _levelparent);

                    iterate++;
                } else continue;
            }
        }

        /// <summary> Генерация уровня на указанной высоте </summary>
        private void GenerateUpLayer(ushort zCoord) {
            byte neighborCunter = 0;

            zCoord--;
            for (ushort xCoord = 1; xCoord < _mapWidth - 1; xCoord++) {
                for (ushort yCoord = 1; yCoord < _mapHeigth - 1; yCoord++) {
                    neighborCunter = ChechNeighbor(new mapCoord(xCoord, yCoord), zCoord);

                    if (neighborCunter > 2 && _mapCoord[xCoord, yCoord, zCoord] != 0 && Random.Range(0, 100) < 40) {
                        GameObject newTile = _meshData.meshObjects[0];
                        _mapCoord[xCoord, yCoord, zCoord + 1] = 1;

                        GameObject.Instantiate(newTile, new Vector3(xCoord, zCoord + 1, yCoord), newTile.transform.rotation, _levelparent);
                    } else if (neighborCunter > 3 && _mapCoord[xCoord, yCoord, zCoord] != 0 && Random.Range(0, 100) < 60) {
                        GameObject newTile = _meshData.meshObjects[0];
                        _mapCoord[xCoord, yCoord, zCoord + 1] = 1;

                        GameObject.Instantiate(newTile, new Vector3(xCoord, zCoord + 1, yCoord), newTile.transform.rotation, _levelparent);
                    }

                    neighborCunter = 0;
                }
            }
        }

        /// <summary> Проверка количества соседей </summary>
        private byte ChechNeighbor(mapCoord coord, ushort level = 0) {
            byte counter = 0;

            if (_mapCoord[coord.x - 1, coord.y, level] != 0) counter++;
            if (_mapCoord[coord.x + 1, coord.y, level] != 0) counter++;
            if (_mapCoord[coord.x, coord.y - 1, level] != 0) counter++;
            if (_mapCoord[coord.x, coord.y + 1, level] != 0) counter++;

            return counter;
        }

        /// <summary> Поиск координаты следующей точки </summary>
        /// <param name="coord"> Текущие координаты </param>
        /// <param name="level"> Уровень карты </param>
        /// <returns> Новые координаты </returns>
        private mapCoord RandomiseCoord(mapCoord coord, ushort level = 0) {
            if (coord.y < _mapHeigth - 1 && coord.y > 0 && Random.Range(0, 100) < 48) {
                if (Random.Range(0, 100) < 48) coord.y++;
                else coord.y--;
            } else if (coord.x < _mapWidth - 1 && coord.x > 0 && Random.Range(0, 100) < 48) {
                if (Random.Range(0, 100) < 48) coord.x++;
                else coord.x--;
            } else if (coord.x == 0 && _mapCoord[coord.x + 1, coord.y, level] == 0) coord.x++;
            else if (coord.x == _mapWidth - 1 && _mapCoord[coord.x - 1, coord.y, level] == 0) coord.x--;
            else if (coord.y == 0 && _mapCoord[coord.x, coord.y + 1, level] == 0) coord.y++;
            else if (coord.y == _mapHeigth - 1 && _mapCoord[coord.x, coord.y - 1, level] == 0) coord.y--;

            return coord;
        }

        /// <summary> Поиск случайных координат внутри игровой области </summary>
        private mapCoord FindCoordinate() => new mapCoord(Random.Range(_mapWidth / 4, _mapWidth / 2), Random.Range(_mapHeigth / 4, _mapHeigth / 2));

        #endregion
    }
}