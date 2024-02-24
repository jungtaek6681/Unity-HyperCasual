using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private BaseScene curScene;

    public void Init()
    {

    }

    public T CurScene<T>() where T : BaseScene
    {
        if (curScene == null)
        {
            curScene = FindObjectOfType<T>();
        }

        return curScene as T;
    }
}
