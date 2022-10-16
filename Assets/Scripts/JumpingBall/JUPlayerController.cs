using UnityEngine;
using System.Collections;

public class JUPlayerController : MonoBehaviour
{
    [SerializeField]
    private JUPlatformSpawner platformSpawner;
    [SerializeField]
    private JUGameController gameController;

    [SerializeField]
    private Transform playerObject;

    [SerializeField]
    private float xSensitivity = 10.0f;

    [SerializeField]
    private float moveTime = 1.0f;
    [SerializeField]
    private float minPositionY = 0.55f;
    private float gravity = -9.81f;
    private int platformIndex = 0;

    private RaycastHit hit;

    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameController.GameStart();

                StartCoroutine("MoveLoop");

                StartCoroutine("DecreaseMoveTime");

                break;
            }

            yield return null;
        }

    }

    private IEnumerator MoveLoop()
    {
        while (true)
        {
            platformIndex++;

            float current = (platformIndex - 1) * platformSpawner.ZDistance;
            float next = platformIndex * platformSpawner.ZDistance;

            yield return StartCoroutine(MoveToYZ(current, next));

            if (hit.transform != null)
            {
                gameController.IncreaseScore();
            }

            else
            {
                gameController.GameOver();
                break;
            }
        }
    }

    private void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f);

        if (Input.GetMouseButton(0))
        {
            MoveToX();
        }
    }

    private void MoveToX()
    {
        float x = 0.0f;
        Vector3 position = transform.position;

        if(Application.isMobilePlatform)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                x = (touch.position.x / Screen.width) - 0.5f;
            }
        }

        else
        {
            x = (Input.mousePosition.x / Screen.width) - 0.5f;
        }

        x = Mathf.Clamp(x, -0.5f, 0.5f);
        position.x = Mathf.Lerp(position.x, x * xSensitivity, xSensitivity * Time.deltaTime);

        transform.position = position;
    }

    private IEnumerator MoveToYZ(float start, float end)
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            float y = minPositionY + (v0 * percent) + (gravity * percent * percent);
            playerObject.position = new Vector3(playerObject.position.x, y, playerObject.position.z);

            float z = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(transform.position.x, transform.position.y, z);

            yield return null;
        }
    }

    private IEnumerator DecreaseMoveTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);

            moveTime -= 0.02f;

            if (moveTime <= 0.2f)
            {
                break;
            }
        }
    }
}
