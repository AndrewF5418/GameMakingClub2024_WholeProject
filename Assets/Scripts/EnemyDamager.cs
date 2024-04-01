using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    //blocking layer
    //[SerializeField] public LayerMask hitLayerMask=Enemy;
    public float damageAmount=1f;

    //skill design:knockback
    public bool isKnock;


    //bool
    private bool damageOverTime=true;
    //list
    private List<EnemyNormalController> enemiesInRange=new List<EnemyNormalController>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<enemiesInRange.Count;i++){
            if(enemiesInRange[i]!=null){
                enemiesInRange[i].TakeDamage(damageAmount,isKnock);
            }
            else{
                enemiesInRange.RemoveAt(i);
                i--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(!damageOverTime){
        if(collision.tag=="Enemy"){
            collision.GetComponent<EnemyNormalController>().TakeDamage(damageAmount,isKnock);
        }
        }
        else{
        if(collision.tag=="Enemy"){
            enemiesInRange.Add(collision.GetComponent<EnemyNormalController>());
        }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(damageOverTime){
            if(collision.tag=="Enemy"){
            enemiesInRange.Remove(collision.GetComponent<EnemyNormalController>());
        }
        }
    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Enenmy"))
    //     {
    //         EnemyNormal enemyNormal = collision.gameObject.GetComponent<EnemyNormalController>();
    //     // if(collision.tag=="Enemy")//set enenmy object as "Enemy" tag
    //     // {
    //         if(enemyNormal!=null){
    //         collision.gameObject.GetComponent<EnemyNormalController>().TakeDamage(damageAmount);
    //         }
    //     }
    // }

}
