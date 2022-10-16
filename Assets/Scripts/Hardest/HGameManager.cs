using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HGameManager : MonoBehaviour
{
    public static HGameManager instance;

    public Vector2 playerInitialPosition;

    private GameObject[] enemies;
    private GameObject player;

    void Awake()
    {
        if (instance == null)
            instance = this;

        Time.timeScale = 1f; 
    }
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindWithTag("Player"); 
    }

    public void PlayerReacheGoal()
    {
        player.transform.position = playerInitialPosition;
        player.GetComponent<HPlayer>().moveSpeed += 0.3f;


        foreach(GameObject g in enemies)
        {
            g.GetComponent<HEnemy>().moveSpeed += 1f;
         }

    }

    public void PlayerMiniGame()
    {
        int index = Random.Range(6,8);
        SceneManager.LoadScene(index);
    }
  

    public void ReachGold()
    {
        Debug.Log("Goal");
        Scene scene = SceneManager.GetActiveScene();

        int curScene = scene.buildIndex;
        int nextScene = curScene + 1;

        SceneManager.LoadScene(nextScene);
    }
    public void PlayerDied()
    {
        Time.timeScale = 0f;

        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
