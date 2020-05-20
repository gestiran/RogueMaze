﻿using UnityEngine;

namespace Core {
    [RequireComponent(typeof(ModulesCore), typeof(ControllersCore))]
    public class GameCore : MonoBehaviour {
        public static GameCore instance;
        
        [HideInInspector] public ModulesCore modulesCore;
        [HideInInspector] public ControllersCore controllersCore;

        private void Start() {
            instance = this;

            modulesCore = GetComponent<ModulesCore>();
            controllersCore = GetComponent<ControllersCore>();

            modulesCore.InitAllModules();
            controllersCore.StartAllControllers();
        }

        private void Update() {
            controllersCore.UpdateAllControllers();
        }
    }
}