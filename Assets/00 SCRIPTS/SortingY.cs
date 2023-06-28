using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingY : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
            {
            //Debug.LogError(this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().name);
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                collision.gameObject.GetComponent<TilemapRenderer>().sortingOrder - 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                collision.gameObject.GetComponent<TilemapRenderer>().sortingOrder +1;
        }
     
        
    }
}
