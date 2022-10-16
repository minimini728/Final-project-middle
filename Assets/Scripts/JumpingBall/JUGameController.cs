using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JUGameController : MonoBehaviour
{
    [SerializeField]
    private JUPlatformSpawner platformSpawner;

    [SerializeField]
    private TextMeshProUGUI textTapToPlay;

    [SerializeField]
    private TextMeshProUGUI textScore;
    private int score = 0;


// ������ �÷��̿��� ȹ���ߴ� ���� �ҷ�����
    private void Awake()
    {
        int score = PlayerPrefs.GetInt("LastScore");
        textScore.text = score.ToString();
    }

    public void GameStart()
    {
        textTapToPlay.enabled = false;

        textScore.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        textScore.text = score.ToString();

        if (score % 2 == 0)
        {
            platformSpawner.SetPlatformColor();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("LastScore", score);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LastScore", 0);
    }



}
