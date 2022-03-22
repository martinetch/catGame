using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterAnimation : MonoBehaviour
{

    public PlayerCharacterControler playerCharacterControler = null;

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

    public float VerticalInput
    {
        get 
        {
            if (this.playerCharacterControler != null)
            {
                return this.playerCharacterControler.verticalInput;
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

    public bool IsGrounded
    {
        get 
        {
            if (this.playerCharacterControler != null)
            {
                return this.playerCharacterControler.isGrounded;
            }
            return false;

        }
    }
    
    
    //Animator
    public Animator animator = null;

    void LateUpdate()
    {
        if (this.animator !=null)
        {
            this.animator.SetFloat("Horizontal", Mathf.Abs(this.HorizontalInput));
            this.animator.SetBool("IsGrounded", this.IsGrounded);
            this.animator.SetFloat("Vertical", this.VerticalInput);
           //print(this.Rigidbody2D.velocity.y);
            //this.Animator.SetBool("IsCrouching", this.FoxCharacterController.crouch);

        }
    }
}
