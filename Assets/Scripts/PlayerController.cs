using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //trait
    public float moveSpeed;
    //animator
    public Animator anim;
    //set rigidBody
    private Rigidbody2D rb;
    //movement
    private Vector2 moveInput = new Vector2(0f, 0f);


    // Start is called before the first frame update
    
    void Start()
    {
        //anim = GetComponent(Animator);
        anim.SetBool("isMovingUpDown",false);
        anim.SetBool("isMovingLeft",false);
        anim.SetBool("isMovingRight",false); 
        //set rigidBody
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 moveInput = new Vector3(0f,0f,0f);
        // moveInput.x = Input.GetAxisRaw("Horizontal");
        // moveInput.y = Input.GetAxisRaw("Vertical");
        // moveInput.Normalize();
        //transform.position += moveInput * moveSpeed*Time.deltaTime;
        //use rigidBody to adjust positon instead of transform.position
        
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //blend tree use
        anim.SetFloat("Horizontal",moveInput.x);
        anim.SetFloat("Vertical",moveInput.y);
        anim.SetFloat("Magnitude",moveInput.magnitude);

       

        //blend tree use


        // // set bool for moving animation by if condition 
        // if(moveInput != Vector2.zero){
        //     if(moveInput.x>0 ||
        //     (moveInput.x>0 && Input.GetAxisRaw("Vertical")==1)||
        //     (moveInput.x>0 && Input.GetAxisRaw("Vertical")==-1)
        //     )
        // {
        //     //anim.SetBool("isMovingRight",true);
        //     //using trigger
        //     anim.SetTrigger("isMovingRight");
        // }
        //     if(moveInput.x<0||
        //     (moveInput.x<0 && Input.GetAxisRaw("Vertical")==1)||
        //     (moveInput.x<0 && Input.GetAxisRaw("Vertical")==-1)
        //     )
        // {
        //     //anim.SetBool("isMovingLeft",true);
        //     anim.SetTrigger("isMovingLeft");
        // }
        // //vertical movement animaion
        //     if(Input.GetAxisRaw("Vertical")==1 || Input.GetAxisRaw("Vertical")==-1)
        // {
        //     //anim.SetBool("isMovingUpDown",true);
        //     anim.SetTrigger("isMovingUpDown");
        // }
        // }

        // // else{
        // //     //using bool to activate animation
        // //     // anim.SetBool("isMovingUpDown",false);
        // //     // anim.SetBool("isMovingLeft",false);
        // //     // anim.SetBool("isMovingRight",false); 
        // // }    
    }
    void FixedUpdate(){
        //movement
        moveInput.Normalize();
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);
    }
    
}
