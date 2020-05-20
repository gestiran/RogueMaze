using UnityEngine;

namespace Core {
    /// <summary> Инициализация игрового процесса, главная точка входа в игру </summary>
    [RequireComponent(typeof(ModulesCore), typeof(ControllersCore))]
    public class GameCore : MonoBehaviour {
        public static GameCore instance;
        
        [HideInInspector] public ModulesCore modulesCore;
        [HideInInspector] public ControllersCore controllersCore;

        private void Start() {
            instance = this;

            modulesCore = GetComponent<ModulesCore>();
            controllersCore = GetComponent<ControllersCore>();

            modulesCore.ResetAllModules();
            controllersCore.ResetAllControllers();

            modulesCore.InitAllModules();
            controllersCore.StartAllControllers();
        }

        private void Update() {
            controllersCore.UpdateAllControllers();
        }
    }
}