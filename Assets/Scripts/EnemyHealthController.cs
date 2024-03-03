using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//use UI
using UnityEngine.UI;
public class EnemyHealthController : MonoBehaviour
{
    //attach to enemy's healthSlider
    //get object
    public static EnemyHealthController instance;
    private Transform target;
    //private Transform enemy;
//slider
    public Slider healthSlider;
//trait
    public float adjustSliderPositionHeight=35;
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    public void Awake(){
        instance = this;
    }
    
    void Start()
    {
        target = FindObjectOfType<EnemyNormalController>().transform;//set the position of slider upon the enemy
        //maxHealth = enemy.getHealth();//input the max value of healthslider through getHealth() method written in EnemyNormalController
        
        currentHealth = maxHealth;
        //set healthbar
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //currentHealth = enemy.getHealth(); //update healthslider through getHealth() method written in EnemyNormalController
        healthSlider.value = currentHealth;
        if(currentHealth<=0){
            Destroy(gameObject);
        }
    }
    void LateUpdate(){
        transform.position = new Vector3(target.position.x,target.position.y+adjustSliderPositionHeight,transform.position.z);
    }
}
