using UnityEngine;
using UnityEngine.SceneManagement;

public class MASceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName="")
    {
        if (sceneName == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("MatchingColor");
        }
    }
}
