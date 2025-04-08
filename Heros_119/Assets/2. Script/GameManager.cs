using UnityEngine;

// Game State Manage
public class GameManager : Singleton<GameManager>
{
    // �⺻
    public GameState gameState = GameState.NONE;
    
    public delegate void StateChangedHandler(GameState newState);
    public event StateChangedHandler OnStateChanged;

    // �ѹ��� ������ �ϱ� ������ >> �ܺο��� ���� ����
    protected override void OnAwake()
    {
        SetState(GameState.Run);
    }

    // Event ȣ��
    public void SetState(GameState newState)
    {
        if (gameState == newState) return;
        gameState = newState;
        OnStateChanged?.Invoke(gameState);
    }

    // State Change
    public void Loading()  => SetState(GameState.Loading);
    public void Pause()    => SetState(GameState.Pause);
    public void GameOver() => SetState(GameState.GameOver);
    public void Run()      => SetState(GameState.Run);
}