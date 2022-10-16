using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    public static int numItems;

    Text itemCounterText;

    // Start is called before the first frame update
    void Start()
    {
        numItems = 0;
        itemCounterText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        itemCounterText.text = "Get Stars : " + numItems.ToString();

    }

}
