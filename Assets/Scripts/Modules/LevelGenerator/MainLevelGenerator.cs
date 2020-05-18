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
        private IntCoord _thisCoord;
        private ObjectType _nextTileType;
        private List<MapObjectStats> _createdObject;
        private List<IntCoord> _mapCoord;
        
        public override void Init() {
            _levelparent = GameObject.FindGameObjectWithTag("Level").transform;
            _params = Resources.Load<LevelGenerateParams>("Data/LevelGenerator/level_001");
            _objects = Resources.Load<LevelObjectList>("Data/LevelGenerator/level_object_list");
            _createdObject = new List<MapObjectStats>();
            _mapCoord = new List<IntCoord>();

            CreatePaths();
        }

        private void CreatePaths() {
            int pathLength = (_params.mapWidth + _params.mapHeigth) * 2;
            GameObject segment;

            _thisCoord = FindLevelStart();

            for (int pathId = 0; pathId < pathLength; pathId++) {
                if (!_mapCoord.Contains(_thisCoord)){
                    segment = GameObject.Instantiate(_objects.baseBlock, _thisCoord.ToVector3(), Quaternion.identity, _levelparent);
                    _createdObject.Add(segment.GetComponent<MapObjectStats>());
                    _mapCoord.Add(_thisCoord);
                }
                _thisCoord = GetNextCoord();
            }
        }

        /// <summary> Поиск координат старта </summary>
        private IntCoord FindLevelStart() => new IntCoord(_params.mapWidth / 2, _params.mapHeigth / 2);

        /// <summary> Поиск координат следующей ячейки </summary>
        private IntCoord GetNextCoord() {
            int iterator = 0;
            int moveDirection;
            IntCoord newCoord;

            do {
                iterator++;
                moveDirection = Random.Range(0,4);
                newCoord = _thisCoord;

                switch(moveDirection) {
                    case 0: if (_thisCoord.y < _params.mapHeigth) newCoord.y++; break;
                    case 1: if (_thisCoord.y > 0) newCoord.y--; break;
                    case 2: if (_thisCoord.x < _params.mapWidth) newCoord.x++; break;
                    case 3: if (_thisCoord.x > 0) newCoord.x--; break;
                }
            } while(_mapCoord.Contains(newCoord) && iterator < 20);

            return newCoord;
        }
    }
}