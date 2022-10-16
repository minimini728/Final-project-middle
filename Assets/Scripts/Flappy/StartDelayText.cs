using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartDelayText : MonoBehaviour
{
    Text startDelayText;

    // Start is called before the first frame update
    void Start()
    {
        startDelayText = GetComponent<Text>();
        startDelayText.text = "3";

        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        for (int i = 3; i >= 0; i -= 1)
        {
            switch (i)
            {
                case 3:
                    startDelayText.text = i.ToString();
                    break;
                case 2:
                    startDelayText.text = i.ToString();
                    break;
                case 1:
                    startDelayText.text = i.ToString();
                    break;
                case 0:
                    startDelayText.text = "GO!";
                    break;
            }

            yield return new WaitForSeconds(1f);
        }

        this.gameObject.SetActive(false);
    }
}
