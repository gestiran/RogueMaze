using UnityEngine;

namespace Controllers {
    public enum ControllerStage {
        Stopped, Working, Paused, Destroyed
    }

    public abstract class BaseController : ScriptableObject {
        [HideInInspector] public ControllerStage stage;
        
        public virtual void StartController() { return; }
        public virtual void StopController() { return; }
        public virtual void RestartController() { return; }

        public virtual void UpdateController() { return; }

        public virtual void PauseController() { return; }
        public virtual void ResumeController() { return; }
        
        public virtual void DestroyController() { return; }
    }
}