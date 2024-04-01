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
    private Vector2 direction;
    //hold gadget gadget
    public GameObject[] gadget = new GameObject[4];
    //blocking layer
    [SerializeField] public LayerMask dashLayerMask;
    //skill design bool
    private bool isDashButtonDown;
    public float dashAmount=30f;

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
        direction=moveInput.normalized;
       
        //Skill Design
        
        //detect the player is hold a specific gadget for dash
        // if(gadget[0]!=null){
            if(Input.GetKeyDown(KeyCode.LeftShift)){
                isDashButtonDown=true;
            }
        // }
        


       
    }
    void FixedUpdate(){
       
        //movement
        rb.velocity=direction* moveSpeed;
        
        //skill dash
        if(isDashButtonDown){
            Vector2 dashPosition = rb.position+direction*dashAmount;
            //detect collide
            RaycastHit2D raycastHit2D = Physics2D.Raycast(rb.position,direction,dashAmount,dashLayerMask);
            if(raycastHit2D.collider!=null){
                dashPosition=raycastHit2D.point;
            }
            rb.MovePosition(dashPosition);
            isDashButtonDown=false;
        }

    }
    
}
