using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FButton : MonoBehaviour
{
    bool pauseActive = false;

    public void RestartBtn()
    {
        SceneManager.LoadScene("Flappy");
    }

    
}
