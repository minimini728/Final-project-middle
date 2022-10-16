using UnityEngine;

public class MACubeChecker : MonoBehaviour
{
    [SerializeField]
    private MACubeSpawner cubeSpawner;
    [SerializeField]
    private MAGameController gameController;

    private MACubeController[] touchCubes;

    private int correctCount = 0;
    private int incorrectCount = 0;

    public int CorrectCount
    {
        set => correctCount = Mathf.Max(0, value);
        get => correctCount;
    }

    public int IncorrectCount
    {
        set => incorrectCount = Mathf.Max(0, value);
        get => incorrectCount;
    }

    private void Awake()
    {
        touchCubes = GetComponentsInChildren<MACubeController>();

        for (int i = 0; i < touchCubes.Length; ++i)
        {
            touchCubes[i].Setup(cubeSpawner, this);        
        }
    }

    private void Update()
    {
        if (gameController.IsGameOver == true) return;

        if (CorrectCount + IncorrectCount == touchCubes.Length)
        {
            if(IncorrectCount == 0)
            {
                gameController.IncreaseScore();
            }
            else
            {
                gameController.GameOver();
            }

            CorrectCount = 0;
            IncorrectCount = 0;
        }
    }
}
