using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 change;
    Animator ani;
    void Start()
    {
        ani=this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        updateAni();

    }
    void updateAni()
    {
        if (change.x > 0)
            this.transform.localScale = Vector3.one;
        else if (change.x < 0)
            this.transform.localScale = new Vector3(-1, 1, 1);
        if (change != Vector3.zero)
        {
            ani.SetFloat("MoveX", change.x);
            ani.SetFloat("MoveY", change.y);
            ani.SetBool("Moving", true);
        }
        else
            ani.SetBool("Moving", false);
    }
}
