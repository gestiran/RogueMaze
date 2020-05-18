using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Modules;

namespace GlobalControllers {
    /// <summary> Управление порядком инициализации моделей </summary>
    public class ModulesController : BaseController {

        private BaseModule[] _gameModules;

        /// <summary> Старт контроллера </summary>
        public override void StartController() {
            CreateModules();
            InitModules();
        }

        /// <summary> Создание списка модулей </summary>
        private void CreateModules() {
            _gameModules = new BaseModule[] {
                new Modules.LevelGenerator.MainLevelGenerator()
            };
        }

        /// <summary> Инициализация модулей </summary>
        private void InitModules() {
            foreach (BaseModule module in _gameModules) module.Init();
        }
    }
}