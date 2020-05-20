using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Modules;

namespace CustomGUI.Modules {
    [CustomEditor(typeof(MLevelGenerator))]
    public class MLevelGeneratorGUI : Editor {
        private MLevelGenerator _module;

        private void OnEnable() => _module = (MLevelGenerator)target;

        public override void OnInspectorGUI() {
            EditorGUILayout.Toggle("Enable " , _module.isEnable);
            base.OnInspectorGUI();
        }
    }
}