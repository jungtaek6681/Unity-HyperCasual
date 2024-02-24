using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    [SerializeField] int bestScore;
    public int BestScore { get { return bestScore; } set { bestScore = value; OnBestScoreChanged?.Invoke(value); } }
    public event UnityAction<int> OnBestScoreChanged;
}
