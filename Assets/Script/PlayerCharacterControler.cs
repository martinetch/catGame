using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControler : MonoBehaviour
{
    //RigidBody contain fonctin to apply physical movement
    public Rigidbody2D Rigidbody2D = null;
    
    // Velocity
    private Vector3 velocity = Vector3.zero;

    //Move speed
    [Range(0f, 3f)]
    public float moveSpeedFactor = 0.0f;

    [Header("Physics")]
    public Transform groundChecker = null;
    public bool isGrounded = false;
    public LayerMask groundCheckLayerMask;


    //Input
    [Range(-1f, 1f)]
    public float horizontalInput = 0f;
        //Jump
    public bool jumpInput = false;
    public float jumpForce = 800f;

    [Range(-1f, 1f)]
    public float verticalInput = 0f;

    void Update() {
        //input for horizontal movement
        this.horizontalInput = Input.GetAxisRaw("Horizontal");
        this.verticalInput = Rigidbody2D.velocity.y;//Pour faire voler le personnage hihi
        /*{
            Vector3 targetVelocity = new Vector3( this.Rigidbody2D.velocity.x, this.verticalInput * 10f, 0f);
            this.Rigidbody2D.velocity = Vector3.SmoothDamp(this.Rigidbody2D.velocity, targetVelocity, ref velocity, this.moveSpeedFactor);
        }*/
        //Jump
        this.jumpInput = Input.GetKeyDown(KeyCode.Space);
        if (this.jumpInput && this.isGrounded) {
            this.Rigidbody2D.AddForce(new Vector2(0f,jumpForce) );
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        //Check if grounded
        this.UpdateGroundedStatus();

        // Handle horizontal movement
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector3(this.horizontalInput * 10f, this.Rigidbody2D.velocity.y, 0f);
            // And then smoothing it out and applying it to the character
            this.Rigidbody2D.velocity = Vector3.SmoothDamp(this.Rigidbody2D.velocity, targetVelocity, ref velocity, this.moveSpeedFactor);
        }
        

        //HandleFilp
        this.HandleFlip();
    }

    //Filp
    private bool facingRight = true;

    private void HandleFlip() {
        if (this.horizontalInput > 0 && facingRight != true) {
            Filp();
        }
        else if ( this.horizontalInput < 0 && facingRight == true) {
            Filp();
        }
    }

    private void Filp() {
        facingRight = !facingRight;
        Vector3 invertedScale = transform.localScale;
        invertedScale.x *= -1;

        transform.localScale = invertedScale;
    }

    void UpdateGroundedStatus() 
    {
        //Unset flag
        this.isGrounded = false;

        if (this.groundChecker !=null) 
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.groundChecker.transform.position, 0.2f, this.groundCheckLayerMask );
            if (colliders != null && colliders.Length > 0)
            {
                for (int i=0; i<colliders.Length; i++) 
                {
                    if (colliders[i].gameObject != this.gameObject)
                    {
                        //Log
                        //Debug.Log("I am gorunded on gameObject: "+ colliders[i].gameObject.name);

                        //Set flag
                        this.isGrounded = true;
                    }
                }
            }
        }
    }

}
