using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAni : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] PlayerData _playerData;

    private Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    public bool isAttacking { get; private set; }
    void Start()
    {
        delay = _playerData.delayWeapon;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //PlayerController.Instant.PlayerState = Player_State.Attack;

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
