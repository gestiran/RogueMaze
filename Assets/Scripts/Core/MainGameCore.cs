using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {
    /// <summary> Управляет инициализацией контроллеров и их взаимодействиями с данными </summary>
    public class MainGameCore : MonoBehaviour {

        private BaseController[] _controllers;

        private void Start() {
            CreateControllers();
            StartControllers();
        }

        private void CreateControllers() {
            _controllers = new BaseController[] {
                new GlobalControllers.ModulesController()
            };
        }

        private void StartControllers() {
            foreach (BaseController controller in _controllers) {
                controller.StartController();
            }
        }
    }
}