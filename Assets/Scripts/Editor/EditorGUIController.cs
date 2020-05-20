using UnityEngine;
using UnityEditor;
using Modules;
using Controllers;

namespace CustomGUI {
    public class EditorGUIController : EditorWindow {
        private Object[] objects;

        [MenuItem("Custom GUI/Data controller")]
        public static void ShowWindow() {
            GetWindow<EditorGUIController>("Data Controller");
        }

        private void OnEnable() {
            objects = AssetDatabase.LoadAllAssetsAtPath("Asset/Resources");
        }

        private void OnGUI() {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("DisableAll")) DisableAll();
            EditorGUILayout.EndHorizontal();
        }

        private void DisableAll() {
            for (int objectId = 0; objectId < objects.Length; objectId++) {
                switch (objects[objectId]) {
                    case BaseModule module:
                        module.isEnable = false;
                    break;

                    case BaseController controller:
                        controller.stage = ControllerStage.Stopped;
                    break;
                }
                EditorUtility.SetDirty(objects[objectId]);
            }
        }
    }
}