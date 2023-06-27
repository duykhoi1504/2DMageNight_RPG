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
    [SerializeField] GameObject ava;
    [SerializeField] bool playerInRange;
    [SerializeField] Image AvaNPC;
    [SerializeField] Animator aniAva;
    [SerializeField] bool isAni;
    //[SerializeField]List<Animator> ListAniNPC=new List<Animator>();

    void Start()
    {

        //aniAva.GetComponent<Animator>();
        //aniAva.runtimeAnimatorController = animation;           

        //AvaNPC.GetComponent<Image>().sprite = ava.GetComponent<SpriteRenderer>().sprite;
        //aniAva = transform.GetChild(2).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(diaLogBox.activeInHierarchy)
                diaLogBox.SetActive(false);

           else
            {
                if (isAni == true)
                {
                    aniAva.enabled = true;
                }
                else
                    aniAva.enabled = false;
                diaLogBox.SetActive(true);
                AvaNPC.GetComponent<Image>().sprite = ava.GetComponent<SpriteRenderer>().sprite;
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
