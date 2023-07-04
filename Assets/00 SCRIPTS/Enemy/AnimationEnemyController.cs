using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyController : MonoBehaviour
{
    [SerializeField] AniBase aniBase;       
    // Start is called before the first frame update
    void Start()
    {
        aniBase=GetComponent<AniBase>();
    }

    // Update is called once per frame
    void Update()
    {
        aniBase.UpSacle();

    }
}
