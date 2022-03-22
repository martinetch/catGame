using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {   print("Touché");
        // Try to find a player with an inventory attached
        PlayerCharacterHealth playerCharacterHealth = other.GetComponentInParent<PlayerCharacterHealth>();
        if (playerCharacterHealth != null)
        {
            // Attribute key to inventory
            playerCharacterHealth.Damage(1);

            // Push player
            PlayerCharacterControler playerCharacterController = other.GetComponentInParent<PlayerCharacterControler>();
            if (playerCharacterController != null)
            {
                // Is the player left or right of the damage zone center
                bool playerIsOnLeft = (playerCharacterController.transform.position.x < this.transform.position.x);
                if (playerIsOnLeft == true)
                {
                    playerCharacterController.transform.position += (new Vector3(-2f, 1.5f));
                }
                else
                {
                    playerCharacterController.transform.position += (new Vector3(2f, 1.5f));
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}

