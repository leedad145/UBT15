public class Define {
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
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
