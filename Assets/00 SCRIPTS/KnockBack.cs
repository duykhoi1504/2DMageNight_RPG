using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    

    [SerializeField] float thrust;
    [SerializeField] float knockTime;
    [SerializeField] float damage;
    //TextPoupManger textPoup;
    //[SerializeField] GameObject textPoup;

    public float Damage { get => damage; set => damage = value; }

    //[SerializeField] Enemy_State currentState;
    void Start()
    {
        //thrust=_playerData.thrust;
        //knockTime = _playerData.knockTime;
        //damage=_playerData.damage;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rigi =other.GetComponentInParent<Rigidbody2D>();
            if (rigi!=null)
            {
                
                Vector3 dir = (other.transform.position - this.transform.position).normalized * thrust;
                rigi.AddForce(dir, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") )
                {

                    //CameraController.Instant.BeginKick();
                    //currentState = Enemy_State.Stagger;
                    AudioManager.Instant.PLaySFX(CONSTANT.enemyHurt);

                        other.gameObject.GetComponent<EnemyBase>().TakeDamage(Damage);
                    TextPoupManger.Instant.gameObject.GetComponent<TextPoupManger>().getTextPoup(other.gameObject, damage, Color.white);
                    //FloatText(Color.white, other.gameObject);

                    other.gameObject.GetComponent<EnemyBase>().Knock( knockTime);
                    
                }
                if (other.gameObject.CompareTag("Player") )
                {

              

                    //Debug.LogError(other.gameObject.name);
                    other.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
                    TextPoupManger.Instant.gameObject.GetComponent<TextPoupManger>().getTextPoup(other.gameObject, damage, Color.red);

                    //FloatText(Color.red,other.gameObject);
                    other.gameObject.GetComponent<PlayerController>().Knock(knockTime);
                }


            }
        }
    }
    //public void FloatText()
    //{


        //GameObject g2 = Instantiate(textPoup, this.transform.position, Quaternion.identity);
        //g2.GetComponent<TextMesh>().text = "-"+damage.ToString();
        //g2.GetComponent<TextMesh>().color = color;

        //g2.transform.rotation = thisGO.transform.rotation;
        //g2.transform.position = thisGO.transform.position;
    //}

}
