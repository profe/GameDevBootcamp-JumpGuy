using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void SwitchScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
