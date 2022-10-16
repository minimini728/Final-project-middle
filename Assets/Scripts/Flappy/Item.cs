using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField] float speed = -5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        BackScene();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            SfxControl.SfxGetItem();
            ItemCounter.numItems += 1;
            Destroy(gameObject);
        }
    }

    public void BackScene()
    {
        if (ItemCounter.numItems >= 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            return;
        }
    }
}
