using TMPro;
using UnityEngine;

public class BestScoreView : MonoBehaviour
{
    [SerializeField] TMP_Text textView;

    private void OnEnable()
    {
        UpdateScore(Manager.Data.BestScore);
        Manager.Data.OnBestScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        Manager.Data.OnBestScoreChanged -= UpdateScore;
    }

    public void UpdateScore(int score)
    {
        textView.text = $"{score}";
    }
}
