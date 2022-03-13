using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector3 spawnPosition = new Vector3();

    public playerCharacterControler playerCharacterControler = null;
    public followPosition cameraFollowPosition = null;

    //UI Death screen
    public GameObject deathScreen = null;
    // Start is called before the first frame update
    void Start()
    {
        this.spawnPosition = this.playerCharacterControler.transform.position;

        this.deathScreen.SetActive(false);
    }

    public void Die() {
        Debug.LogWarning("Player "+ this.gameObject.name + " is now dead");
        this.deathScreen.SetActive(true);
        //Player controller : stop receiving input
        this.playerCharacterControler.enabled = false;
        //Camera - Stop following player
        this.cameraFollowPosition.enabled = false;



    }

    public void Respawn() {

        this.deathScreen.SetActive(false);
        //reset velocity Rigidbody
        this.playerCharacterControler.Rigidbody2D.velocity = Vector3.zero;
        //Player - Teleport back to spawn position
        this.playerCharacterControler.transform.position = this.spawnPosition;
        //Player controller : activate receiving input
        this.playerCharacterControler.enabled = true;
        //Camera - activate following player
        this.cameraFollowPosition.enabled = true;
    }
}
