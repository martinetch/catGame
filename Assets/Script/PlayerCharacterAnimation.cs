using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAnimation : MonoBehaviour
{

    public playerCharacterControler playerCharacterControler = null;

    public float HorizontalInput
    {
        get 
        {
            if (this.playerCharacterControler != null)
            {
                return this.playerCharacterControler.horizontalInput;
            }
            return 0f;

        }
    }

    // Rigidbody
    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (this.playerCharacterControler != null)
                return this.playerCharacterControler.Rigidbody2D;
            return null;
        }
    }

    public float IsGrounded
    {
        get 
        {
            if (this.playerCharacterControler != null)
            {
                this.playerCharacterControler.jumpInput = Input.GetKeyDown(KeyCode.Space);
                if (this.playerCharacterControler.jumpInput) {
                    return 1.0f;
                }
            }
            return 0f;

        }
    }
    
    
    //Animator
    public Animator animator = null;

    void LateUpdate()
    {
        if (this.animator !=null)
        {
            this.animator.SetFloat("Horizontal", Mathf.Abs(this.HorizontalInput));
            this.animator.SetFloat("IsGrounded", IsGrounded);
            this.animator.SetFloat("Vertical", this.Rigidbody2D.velocity.y);
            //this.Animator.SetBool("IsCrouching", this.FoxCharacterController.crouch);

        }
    }
}
