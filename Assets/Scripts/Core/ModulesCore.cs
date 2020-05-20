using UnityEngine;
using Modules;

namespace Core {
    [RequireComponent(typeof(GameCore))]
    public class ModulesCore : MonoBehaviour {
        [SerializeField] private BaseModule[] _modules;

        /// <summary> Подключает модуль </summary>
        public void InitModule(int moduleId) {
            if (moduleId < _modules.Length && _modules[moduleId] != null && !_modules[moduleId].isEnable) {
                _modules[moduleId].isEnable = true;
                _modules[moduleId].Init();
            }
        }

        /// <summary> Подключает все модули </summary>
        public void InitAllModules() {
            foreach (BaseModule module in _modules) {
                if (module != null && !module.isEnable) {
                    module.isEnable = true;
                    module.Init();
                }
            }
        }

        /// <summary> Отключает модуль </summary>
        public void DisableModule(int moduleId) {
            if (moduleId < _modules.Length && _modules[moduleId] != null && _modules[moduleId].isEnable) {
                _modules[moduleId].isEnable = false;
                _modules[moduleId].Destroy();
            }
        }

        /// <summary> Отключает все модули </summary>
        public void DisableAllModules() {
            foreach (BaseModule module in _modules) {
                if (module != null && module.isEnable) {
                    module.isEnable = false;
                    module.Destroy();
                }
            }
        }
    }
}