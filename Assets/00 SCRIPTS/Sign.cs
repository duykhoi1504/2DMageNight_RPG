using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject diaLogBox;
    [SerializeField] Text diaLogText;
    public string textDialog;
    bool playerInRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(diaLogBox.activeInHierarchy)
                diaLogBox.SetActive(false);

           else
            {
                diaLogBox.SetActive(true);

                diaLogText.text = textDialog;
            
            }
        }
           

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerInRange = false;
        diaLogBox.SetActive(false);
    }
}
