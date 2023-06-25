using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _ContextClue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Chest>() != null)
        {
            _ContextClue.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Chest>() != null)
        {
            _ContextClue.gameObject.SetActive(false);
        }
    }
}
