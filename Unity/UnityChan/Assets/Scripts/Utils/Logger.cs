using System.Diagnostics;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Logger // 래핑클래스
{
    [Conditional("DEV_VER")]
    public static void Log(string msg) // 일반 로그
    {
        UnityEngine.Debug.LogFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogWarning(string msg) // 경고 로그
    {
        UnityEngine.Debug.LogWarningFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }
    [Conditional("DEV_VER")]
    public static void LogError(string msg) // 에러 로그
    {
        UnityEngine.Debug.LogErrorFormat("[{0}] {1}", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), msg);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}