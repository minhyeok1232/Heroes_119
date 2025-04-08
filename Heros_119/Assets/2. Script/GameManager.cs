using UnityEngine;

// Game State Manage
public class GameManager : Singleton<GameManager>
{
    // 기본
    public GameState gameState = GameState.NONE;
    
    public delegate void StateChangedHandler(GameState newState);
    public event StateChangedHandler OnStateChanged;

    // 한번만 실행을 하기 때문에 >> 외부에서 접근 금지
    protected override void OnAwake()
    {
        SetState(GameState.Run);
    }

    // Event 호출
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