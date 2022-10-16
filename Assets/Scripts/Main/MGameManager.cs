using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGameManager : MonoBehaviour
{
    public void SFlappy()
    {
        SceneManager.LoadScene("Flappy");
    }

    public void SDdongavoid()
    {
        SceneManager.LoadScene("Ddongavoid");
    }

    public void SMemory()
    {
        SceneManager.LoadScene("Memory");
    }
    public void SSlidingPuzzle()
    {
        SceneManager.LoadScene("SlidingPuzzle");
    }
    public void SHardest()
    {
        SceneManager.LoadScene("Hardest");
    }
    public void SMaze()
    {
        SceneManager.LoadScene("Maze");
    } 
    public void SBrick()
    {
        SceneManager.LoadScene("Global");
    }
}
