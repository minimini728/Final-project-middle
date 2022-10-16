using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject poop;

    private int score;

    [SerializeField]
    private Text scoreTxt;
    

    [SerializeField]
    private Text bestScore;
    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool stopTrigger = true;
    public void Gameover()
    {
        stopTrigger = false;

        StopCoroutine(CreatepoopRoutine());

        if(score >= PlayerPrefs.GetInt("BestScore", 0))
        PlayerPrefs.SetInt("BestScore",score);

        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void GameStart()
    {
        stopTrigger = true;
        StartCoroutine(CreatepoopRoutine());
        panel.SetActive(false);
    }

    public void Score()
    {
        score++;
        scoreTxt.text = "Score : " + score;
    }

    IEnumerator CreatepoopRoutine()
    {
        while (true)
        {
            CreatePoop();
            yield return new WaitForSeconds(1);
        }
        
    }

    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        GameObject obj = Instantiate(poop, pos, Quaternion.identity);
        
    }
}
