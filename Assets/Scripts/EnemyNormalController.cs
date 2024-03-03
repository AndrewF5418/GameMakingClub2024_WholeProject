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
    public float health=5f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //follow PlayerController
        theRigidBody.velocity = (target.position - transform.position).normalized * moveSpeed;
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
}
