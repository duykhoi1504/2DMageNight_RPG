using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAni : MonoBehaviour
{
    // Start is called before the first frame update
  

    private Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public bool isAttacking { get; private set; }
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            attack();
        }
    }
    public void attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        isAttacking = true;
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
