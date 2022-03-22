using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portail : MonoBehaviour
{
    public Player mainPlayer = null;
    public PlayerCharacterInventory playerCharacterInventory =null;
    public PlayerCharacterAnimation animation = null;
    public int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //this.playerCharacterInventory.keyCount = 0;
        this.animation.animator.SetTrigger("Teleport");
        StartCoroutine(animationTime());
         
    }

    IEnumerator animationTime() {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1f);
        this.mainPlayer.NewLevel(nextLevel);  
    }
}
