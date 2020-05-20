using UnityEngine;

namespace Modules {
    /// <summary> Описывает базовый функционал игровых модулей </summary>
    public abstract class BaseModule : ScriptableObject {

        /// <summary> Активность </summary>
        [HideInInspector] public bool isEnable;

        /// <summary> Инициализация модуля Start </summary>
        public abstract void Init();

        /// <summary> Принудительное завершение работы модуля </summary>
        public abstract void Destroy();
    }
}