using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameScene : BaseScene
{
    public enum State { Ready, Play, GameOver }

    public State curState { get; private set; }

    public UnityEvent OnReadyed;
    public UnityEvent OnPlayed;
    public UnityEvent OnGameOvered;

    private void Start()
    {
        Ready();
    }

    private void ChangeState(State state)
    {
        curState = state;
        switch (state)
        {
            case State.Ready:
                OnReadyed?.Invoke();
                break;
            case State.Play:
                OnPlayed?.Invoke();
                break;
            case State.GameOver:
                OnGameOvered?.Invoke();
                break;
        }
    }

    public void Ready()
    {
        ChangeState(State.Ready);
    }

    public void Play()
    {
        ChangeState(State.Play);
    }

    public void GameOver()
    {
        ChangeState(State.GameOver);
    }

    private void OnPlay(InputValue value)
    {
        if (curState == State.Ready)
        {
            Play();
        }
    }
}
