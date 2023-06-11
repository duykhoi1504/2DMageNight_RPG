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
        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerController.Instant.PlayerState = Player_State.Attack;
            StartCoroutine(AttackCo());
        }
        updateAni();
        scaleAniToMouse();


    }
    void scaleAniToMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = ((Vector2)mouse - (Vector2)transform.position).normalized;
        Vector2 scale = transform.localScale;
        if (dir.x > 0)
            scale.x = 1;
        else if (dir.x < 0)
            scale.x = -1;
        this.transform.localScale = scale;
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
    private IEnumerator AttackCo()
    {
        ani.SetBool("Attacking", true);
        yield return null;
        ani.SetBool("Attacking", false);
        yield return new WaitForSeconds(.33f);

    }
}
