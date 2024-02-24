using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Manager.Scene.LoadScene(sceneName);
    }
}
