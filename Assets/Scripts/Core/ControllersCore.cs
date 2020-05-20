using UnityEngine;
using Controllers;

namespace Core {
    /// <summary> Функционал игровых контроллеров </summary>
    [RequireComponent(typeof(GameCore))]
    public class ControllersCore : MonoBehaviour{
        [SerializeField] private BaseController[] _controllers;

        /// <summary> Сбросить состояние активации перед стартом </summary>
        public void ResetAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null) controller.stage = ControllerStage.Stopped;
            }
        }

        /// <summary> Запускает контроллер </summary>
        public void StartController(int controllerId) {
            if (controllerId < _controllers.Length && _controllers[controllerId] != null && _controllers[controllerId].stage == ControllerStage.Stopped) {
                _controllers[controllerId].stage = ControllerStage.Working;
                _controllers[controllerId].StartController();
            }
        }

        /// <summary> Запускает все контроллеры </summary>
        public void StartAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Stopped) {
                    controller.stage = ControllerStage.Working;
                    controller.StartController();
                }
            }
        }

        /// <summary> Обновить все контроллеры </summary>
        public void UpdateAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Working) controller.UpdateController();
            }
        }

        /// <summary> Останавливает контроллер </summary>
        public void StopController(int controllerId) {
            if (controllerId < _controllers.Length && _controllers[controllerId] != null && _controllers[controllerId].stage == ControllerStage.Working) {
                _controllers[controllerId].stage = ControllerStage.Stopped;
                _controllers[controllerId].StopController();
            }
        }

        /// <summary> Останавливает все контоллеры </summary>
        public void StopAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Working) {
                    controller.stage = ControllerStage.Stopped;
                    controller.StopController();
                }
            }
        }

        /// <summary> Ставит включенный контроллер на паузу </summary>
        public void PauseController(int controllerId) {
            if (controllerId < _controllers.Length && _controllers[controllerId] != null && _controllers[controllerId].stage == ControllerStage.Working) {
                _controllers[controllerId].stage = ControllerStage.Paused;
                _controllers[controllerId].PauseController();
            }
        }

        /// <summary> Ставит включенные контроллеры на паузу </summary>
        public void PauseAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Working) {
                    controller.stage = ControllerStage.Paused;
                    controller.PauseController();
                }
            }
        }

        /// <summary> Перезапускает контроллер в рабочем состоянии </summary>
        public void RestartController(int controllerId) {
            if (controllerId < _controllers.Length && _controllers[controllerId] != null && _controllers[controllerId].stage == ControllerStage.Working) {
                _controllers[controllerId].RestartController();
                _controllers[controllerId].stage = ControllerStage.Working;
            }
        }

        /// <summary> Перезапускает все рабочие контроллеры </summary>
        public void RestartAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Working) {
                    controller.RestartController();
                    controller.stage = ControllerStage.Working;
                }
            }
        }

        /// <summary> Продолжает работу контроллера </summary>
        public void ResumeController(int controllerId) {
            if (controllerId < _controllers.Length && _controllers[controllerId] != null && _controllers[controllerId].stage == ControllerStage.Paused) {
                _controllers[controllerId].ResumeController();
                _controllers[controllerId].stage = ControllerStage.Working;
            }
        }

        /// <summary> Продолжает работу всех контроллеров </summary>
        public void ResumeAllControllers() {
            foreach (BaseController controller in _controllers) {
                if (controller != null && controller.stage == ControllerStage.Paused) {
                    controller.ResumeController();
                    controller.stage = ControllerStage.Working;
                }
            }
        }
    }
}