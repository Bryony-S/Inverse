using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonScript : MonoBehaviour
{
    /// <summary>
    /// Load scene by name
    /// </summary>
    /// <param name="sceneName">The name of the scene to load</param>
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName)) SceneManager.LoadScene(sceneName);
    }
}
