using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Thunder : AbilityBase
{

    [SerializeField] GameObject thunder;
    [SerializeField] float manaUse;
    //[SerializeField] float speedSpell;

    // Start is called before the first frame update

    public override void Activate(GameObject parent)
    {
        if(PlayerController.Instant.mana<=0 || PlayerController.Instant.mana< manaUse) return;
        PlayerController.Instant.mana -= 10f;

        

        AudioManager.Instant.PLaySFX(CONSTANT.thunder);
        GameObject fireball = Instantiate(thunder, parent.transform.position, Quaternion.identity);

        fireball.transform.localPosition += new Vector3(0f, 1f, 0f);
        Destroy(fireball,2f);
        CoroutineHandler.Instance.StartCoroutine(SpreadEffectCo(1f));



    }
    public override void BeginCoolDown(GameObject parent)
    {

    }
    IEnumerator SpreadEffectCo(float time)
    {
        yield return new WaitForSeconds(time);
        Vector3 right = PlayerController.Instant.transform.position + new Vector3(5f, 0f, 0f);
        Vector3 left = PlayerController.Instant.transform.position + new Vector3(-5f, 0f, 0f);
        Vector3 down = PlayerController.Instant.transform.position + new Vector3(0f, -5f, 0f);
        Vector3 top = PlayerController.Instant.transform.position + new Vector3(0f, 5f, 0f);
        

        GameObject fireball1 = Instantiate(thunder, right, Quaternion.identity);
        GameObject fireball2 = Instantiate(thunder, left, Quaternion.identity);
        GameObject fireball3 = Instantiate(thunder, down, Quaternion.identity);
        GameObject fireball4 = Instantiate(thunder, top, Quaternion.identity);

        Destroy(fireball1, 2f);
        Destroy(fireball2, 2f);
        Destroy(fireball3, 2f);
        Destroy(fireball4, 2f);

        AudioManager.Instant.PLaySFX(CONSTANT.thunder);
    }
}
public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler instance;

    public static CoroutineHandler Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("CoroutineHandler");
                instance = obj.AddComponent<CoroutineHandler>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }
}
