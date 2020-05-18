using UnityEngine;

namespace Modules.LevelGenerator {

    /// <summary> Тип тайла </summary>
    public enum ObjectType {
        Start, Finish,
        UpEnd, DownEnd, LeftEnd, RightEnd,
        UpLeftAngle, UpRightAngle, DownLeftAngle, DownRightAngle,
        VerticalTonnel, HorizontalTonnel,
        UpTriple, DownTriple, LeftTriple, RightTriple,
        Crossroads
    }

    /// <summary> Наполнение обьекта </summary>
    public enum ObjectFilling {
        Empty, Enemy, Trap, Reward
    }

    /// <summary> Описывает состояние обьекта </summary>
    public class MapObjectStats : MonoBehaviour {
        public ObjectType objectType;
        public ObjectFilling objectFilling;
    }
}