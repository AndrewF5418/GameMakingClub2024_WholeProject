using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthController : MonoBehaviour
{
public static PlayerHealthController instance;
public Slider healthSlider;
//trait
public float currentHealth;
public float maxHealth;
    // Start is called before the first frame update
    private void Awake(){
        instance = this;
    }
    void Start()
    {
        //set up health slider in order
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;//#1 step
        healthSlider.value = currentHealth;//#2 step
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void TakeDamage(float damageToTake){
        currentHealth -= damageToTake;
        if(currentHealth<=0){
            gameObject.SetActive(false);
        }
        healthSlider.value = currentHealth;
    }
}