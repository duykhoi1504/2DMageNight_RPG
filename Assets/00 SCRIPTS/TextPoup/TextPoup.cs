using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPoup : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]float timeCount = 0;
    void Start()
    {
        
       //this.transform.localPosition+=new Vector3(0f, 1f, 0f);
        
        //Destroy(gameObject,2f);

    }
    private void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > 2f)
        {
            this.gameObject.SetActive(false);
            timeCount = 0;
        }
    }


    // Update is called once per frame

}
