public class Define {
    public enum InputEvent
    {
        UIEvent,
        MouseMove,
        LPress,
        RPress,
        LClick,
        RClick,
        RLClick,
        RUp,
        LUp,
        KeyPress,
    }
    public enum PlayerState
    {
        Idle,
        Run,
        Attack,
        Dead = 10,
    }
    public enum MonsterState
    {
        Idle,
        Run,
        Attack,
        Dead = 10,
    }
}
