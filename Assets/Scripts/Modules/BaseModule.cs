using UnityEngine;

namespace Modules {
    public abstract class BaseModule : ScriptableObject {
        [HideInInspector] public bool isEnable;

        public abstract void Init();
        public abstract void Destroy();
    }
}