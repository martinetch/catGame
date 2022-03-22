using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyLock : MonoBehaviour
{
    // Door
    public GameObject portail1 = null;
    public GameObject portail2 = null;
    public GameObject portail3 = null;
    public PlayerCharacterInventory playerCharacterInventory =null;

    // Flag
    private bool opened = false;

    void Start()
    {
        // Disable portail to prevent it from moving
        this.portail1.SetActive(false);
        this.portail2.SetActive(false);
        this.portail3.SetActive(false);
    }

    // Trigger Enter
    void Update()
    {
        // Prevent potential issues
        if (this.opened == true)
            return;

        // Try to find a player with an inventory attached
        if (playerCharacterInventory != null)
        {
            //print(playerCharacterInventory.keyCount);
            // If enough keys
            if (playerCharacterInventory.keyCount >= 5)
            {
                
                // Enabling door will make it move
                this.portail1.SetActive(true);

                // Unset flag
                this.opened = false;

                // Delete key from scene (and prevent further use)
                //GameObject.Destroy(this.gameObject);
            }
            if (playerCharacterInventory.keyCount >= 10) {
                    this.portail2.SetActive(true);
            }
            if (playerCharacterInventory.keyCount >= 15) {
                    this.portail3.SetActive(true);
            }
        }
    }
}
