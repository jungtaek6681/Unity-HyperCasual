using TMPro;
using UnityEngine;

public class CurScoreView : MonoBehaviour
{
    [SerializeField] TMP_Text textView;

    private void OnEnable()
    {
        if (Manager.Scene.CurScene<GameScene>() != null)
        {
            UpdateScore(Manager.Scene.CurScene<GameScene>().CurScore);
            Manager.Scene.CurScene<GameScene>().OnCurScoreChanged += UpdateScore;
        }
    }

    private void OnDisable()
    {
        if (Manager.Scene.CurScene<GameScene>() != null)
        {
            Manager.Scene.CurScene<GameScene>().OnCurScoreChanged -= UpdateScore;
        }
    }

    public void UpdateScore(int score)
    {
        textView.text = $"{score}";
    }
}
