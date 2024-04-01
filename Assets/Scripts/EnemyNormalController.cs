using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalController : MonoBehaviour
{
    //get object
    public Rigidbody2D theRigidBody;
    //move
    public float moveSpeed;
    //trace player by get target object
    private Transform target;

    //drop item
    public GameObject dropItem;
    //attack
    public float damage;
    public float hitWaitTime = 1f;
    private float hitCounter;
    //health
    public static EnemyNormalController instance;
    public float health=5f;

    //skill design
    //knock back;
    public float knockBackTime = 0.5f;
    public float knockBackFactor = 2f;
    private float knockBackCounter=0;
    
    // Start is called before the first frame update
    void Awake(){
        instance=this;
    }
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        //attack
        if(hitCounter > 0f)
        {
            hitCounter -= Time.deltaTime;
        }
        if(health<=0)
        {   
            Instantiate(dropItem, transform.position, transform.rotation);//drop item as the location it died
            Destroy(gameObject);
        }
    }
    //physics calculation in fixed update
    void FixedUpdate() {
        //knockback skill design
        if(knockBackCounter>0){
            knockBackCounter-=Time.deltaTime;
            if(moveSpeed>0){
                moveSpeed=-moveSpeed*knockBackFactor;
            }
            if(knockBackCounter<0){
                moveSpeed=Mathf.Abs(moveSpeed/knockBackFactor);
            }
        }

        //follow PlayerController
        theRigidBody.velocity = (target.position - transform.position).normalized * moveSpeed;
    }

    public float getHealth(){
        return health;
    }
    
    //damage player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //identify it collides player, using tag "Player"
        if(collision.gameObject.tag == "Player" && hitCounter<=0f)
        {
        //damage
          PlayerHealthController.instance.TakeDamage(damage);
          hitCounter = hitWaitTime;
        }
    }
    //take damage and if health is 0, destroy it self and drop item
    public void TakeDamage(float damageToTake){
        health -= damageToTake;
        if(health<=0)
        {   
            Instantiate(dropItem, transform.position, transform.rotation);//drop item as the location it died
            Destroy(gameObject);
        }
    }
    //skill design:KnockBack
    public void TakeDamage(float damageToTake,bool isKnock){
        TakeDamage(damageToTake);
        if(gameObject!=null){
        if(isKnock){
            knockBackCounter=knockBackTime;
        }}
    }
}
