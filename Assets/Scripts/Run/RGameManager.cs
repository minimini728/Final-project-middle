using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGameManager : MonoBehaviour
{
    public static RGameManager instance;
    #region instance
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void Onplay(bool isplay);
    public Onplay onPlay;

    public float gameSpeed = 1;
    public bool isPlay = false;
    public GameObject playBtn;

    public Text bestScoreTxt;
    public Text scoreTxt;
    public int score = 0;


    private void Start()
    {
        bestScoreTxt.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    IEnumerator AddScore()
    {
        while (isPlay)
        {
            score++;
            scoreTxt.text = score.ToString();
            gameSpeed = gameSpeed + 0.01f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void PlayBtnClick()
    {
        playBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        score = 0;
        scoreTxt.text = score.ToString();
        StartCoroutine(AddScore());
    }

    public void GameOver()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
        StopCoroutine(AddScore());
        if (PlayerPrefs.GetInt("BestScore", 0) < score)
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScoreTxt.text = score.ToString();
        }

       
            
    }
}
