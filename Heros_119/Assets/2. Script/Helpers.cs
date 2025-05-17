using UnityEngine;

public enum GameState
{
    NONE,       // �ʱ�
    Loading,    // �ε�
    Run,        // ���� ��
    Pause,      // �Ͻ�����
    GameOver    // ���ӿ���
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