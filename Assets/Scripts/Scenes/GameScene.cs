using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameScene : BaseScene
{
    public enum State { Ready, Play, GameOver }

    public State curState { get; private set; }

    private int curScore;
    public int CurScore { get { return curScore; } private set { curScore = value; OnCurScoreChanged?.Invoke(value); } }
    public event UnityAction<int> OnCurScoreChanged;

    [SerializeField] AudioSource scoreSound;

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

    public void GetScore()
    {
        CurScore++;
        if (curScore > Manager.Data.BestScore)
        {
            Manager.Data.BestScore = curScore;
        }
        scoreSound.Play();
    }

    private void OnPlay(InputValue value)
    {
        if (curState == State.Ready)
        {
            Play();
        }
    }
}
