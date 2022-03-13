using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform startTransform = null;
    public Transform endTransform = null;
    public float moveSpeed = 1.0f;
    public float percentage = 0.0f; //0.0 <-> 1.0

    public Rigidbody2D rigidbody2D = null;

    public bool moveDirection = false;
    // Update is called once per frame
    void Update()
    {
        if (this.moveDirection) {
            //Raise percentage
            this.percentage = Mathf.Clamp01(this.percentage + this.moveSpeed * Time.deltaTime);
            //End reached
            this.moveDirection = (this.percentage != 1.0f);
        } else {
            this.percentage = Mathf.Clamp01(this.percentage - this.moveSpeed * Time.deltaTime);
            this.moveDirection = (this.percentage == 0.0f);
        }
    }

    void FixedUpdate() {
        if (this.rigidbody2D != null) {
            Vector2 newPosition = Vector2.Lerp(this.startTransform.position, this.endTransform.position, this.percentage);
            this.rigidbody2D.MovePosition(newPosition);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.startTransform.position, this.endTransform.position);
    }
}
