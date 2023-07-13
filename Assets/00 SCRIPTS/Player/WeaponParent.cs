using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer characterRenderer, weaponRenderer,bowRenderer,ChangeRenderer;

    public Vector2 PointerPosition { get; set; }
    private Animator animator;
    //public float delay = 0.3f;
    private bool attackBlocked;
    public bool isAttacking { get; private set; }
    [SerializeField]float cancelWeapon=1f;
    public void resetIsAttacking()
    {
        isAttacking = false;
    }
    void Start()
    {
        ChangeRenderer = weaponRenderer;
    }

    // Update is called once per frame
    void Update()
    {


        if (isAttacking) return;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = ((Vector2)mouse - (Vector2)transform.position).normalized;
        transform.right = dir;
        Vector2 scale = transform.localScale;
        if (dir.x < 0)
        {
            scale.y = -1;
        } else if (dir.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;
        if (transform.eulerAngles.z> 0 && transform.eulerAngles.z < 180) 
        {
            ChangeRenderer.sortingOrder = characterRenderer.sortingOrder - 1;
        }else {
            ChangeRenderer.sortingOrder = characterRenderer.sortingOrder + 1;
        }
        changeWeapon();
    }
    void changeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeRenderer = weaponRenderer;
            bowRenderer.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeRenderer = bowRenderer;
            weaponRenderer.gameObject.SetActive(false);

        }
        CancelWeapon();

    }
    void CancelWeapon()
    {
       
            if (Input.GetKeyDown(KeyCode.Z))
            {
                cancelWeapon *= -1;

            }
            if (cancelWeapon != 1)
            {

            ChangeRenderer.gameObject.SetActive(false);
            }
            else
            {
            ChangeRenderer.gameObject.SetActive(true);
            }
        
    }
    //public void attack()
    //{
    //    if (attackBlocked) 
    //        return;
    //    animator.SetTrigger("Attack");
    //    isAttacking = true;
    //    attackBlocked = true;
    //    StartCoroutine(DelayAttack());    
    //}
    //private IEnumerator DelayAttack()
    //{
    //    yield return new WaitForSeconds(delay);
    //    attackBlocked = false;
    //}
}
