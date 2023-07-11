using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPoup : MonoBehaviour
{
    // Start is called before the first frame update

  
    void Start()
    {
       this.transform.localPosition+=new Vector3(0f, 1f, 0f);
        Destroy(gameObject,2f);

    }
 

    // Update is called once per frame
    
}
