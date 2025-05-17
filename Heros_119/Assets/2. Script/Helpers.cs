using UnityEngine;

public enum GameState
{
    NONE,       // 초기
    Loading,    // 로딩
    Run,        // 실행 중
    Pause,      // 일시정지
    GameOver    // 게임오버
}

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Jump,
    Attack,
    Dead
}

public static class Helpers
{
    // ====================== Debug ======================
    public static void Log(string str)
    {
        #if UNITY_EDITOR
        Debug.Log(str);
        #endif
    }
    
    public static void LogWarning(string str)
    {
        #if UNITY_EDITOR
        Debug.LogWarning(str);
        #endif
    }
    
    public static void LogError(string str)
    {
        #if UNITY_EDITOR
        Debug.LogError(str);
        #endif
    }
}