using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Vector3 spawnPosition = new Vector3();
    public Vector3 level2 = new Vector3();
    public Vector3 level3 = new Vector3();
    public PlayerCharacterHealth playerCharacterHealth = null;

    public PlayerCharacterControler playerCharacterControler = null;
    public followPosition cameraFollowPosition = null;

    //UI Death screen
    public GameObject deathScreen = null;
    public GameObject endScreen = null;
    // Start is called before the first frame update
    void Start()
    {
        this.spawnPosition = this.playerCharacterControler.transform.position;

        this.deathScreen.SetActive(false);
    }

    public void Die(int hp) {
        if (this.playerCharacterHealth.currentHealthPoints > 1) {
            this.playerCharacterHealth.Damage(1);
            this.Respawn(0);
        } else {
            Debug.LogWarning("Player "+ this.gameObject.name + " is now dead");
            this.deathScreen.SetActive(true);
            //Player controller : stop receiving input
            this.playerCharacterControler.enabled = false;
            //Camera - Stop following player
            this.cameraFollowPosition.enabled = false;
        }
    }

    public void Respawn(int test) {
        if (test ==  0) {
            this.deathScreen.SetActive(false);
            //reset velocity Rigidbody
            this.playerCharacterControler.Rigidbody2D.velocity = Vector3.zero;
            //Player - Teleport back to spawn position
            this.playerCharacterControler.transform.position = this.spawnPosition;
            //Player controller : activate receiving input
            this.playerCharacterControler.enabled = true;
            //Camera - activate following player
            this.cameraFollowPosition.enabled = true;
        } else {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        
    }

    public void NewLevel(int level) {
        //reset velocity Rigidbody
        this.playerCharacterControler.Rigidbody2D.velocity = Vector3.zero;
        //Player - Teleport back to spawn position
        if (level == 2)
            this.playerCharacterControler.transform.position = this.level2;
        if (level == 3)
            this.playerCharacterControler.transform.position = this.level3;
        if (level == 4)
            this.endScreen.SetActive(true);
        //Player controller : activate receiving input
        this.playerCharacterControler.enabled = true;
        //Camera - activate following player
        this.cameraFollowPosition.enabled = true;
    }

}

/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Awake()
    {
        // Init Position
        this.InitPositions();

        // Register to health events
        this.RegisterToHealthEvents();
    }

    #region Save Positions / Spawning
    // Vars
    private PlayerCharacterControler playerCharacterController = null;
    public PlayerCharacterControler PlayerCharacterController
    {
        get
        {
            if (this.playerCharacterController == null)
                this.playerCharacterController = this.gameObject.GetComponentInChildren<PlayerCharacterControler>();
            return this.playerCharacterController;
        }
    }

    // Spawn / Respawn position
    private Vector2 spawnPosition = Vector2.zero;
    void InitPositions()
    {
        if (this.PlayerCharacterController != null)
        {
            this.spawnPosition = this.PlayerCharacterController.transform.position;
        }
    }
    #endregion

    #region Health
    // Vars
    private PlayerCharacterHealth playerCharacterHealth = null;
    public PlayerCharacterHealth PlayerCharacterHealth
    {
        get
        {
            if (this.playerCharacterHealth == null)
                this.playerCharacterHealth = this.gameObject.GetComponentInChildren<PlayerCharacterHealth>();
            return this.playerCharacterHealth;
        }
    }

    // Called in Awake / OnEnable / OnDisable
    void RegisterToHealthEvents()
    {
        // Register to health events
        if (this.PlayerCharacterHealth != null)
        {
            this.PlayerCharacterHealth.OnDead.AddListener(this.OnDead);
            this.PlayerCharacterHealth.OnRevive.AddListener(this.OnRevive);
        }
    }

    // Health - Events
    private void OnRevive()
    {
        if (this.PlayerCharacterController != null)
        {
            // Set back to respawn position
            this.PlayerCharacterController.transform.position = this.spawnPosition;

            // Enable back the various components
            {
                // Controller
                this.PlayerCharacterController.enabled = true;

                // Camera
                Camera camera = this.GetComponentInChildren<Camera>();
                if (camera != null)
                {
                    FollowTransform cameraFollowTransform = camera.GetComponent<FollowTransform>();
                    if (cameraFollowTransform != null)
                    {
                        // Enable back
                        cameraFollowTransform.enabled = true;

                        // Reset camera position
                        cameraFollowTransform.transform.position = new Vector3(this.spawnPosition.x, this.spawnPosition.y, cameraFollowTransform.transform.position.z);
                    }
                }

                // Box collider
                BoxCollider2D boxCollider2D = this.PlayerCharacterController.GetComponent<BoxCollider2D>();
                if (boxCollider2D != null)
                    boxCollider2D.enabled = true;

                // Rigidbody
                Rigidbody2D rigidbody2D = this.PlayerCharacterController.GetComponent<Rigidbody2D>();
                if (rigidbody2D != null)
                {
                    // Enable rigidbody to fall again
                    rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    
                    // Reset the velocity
                    rigidbody2D.velocity = Vector2.zero;
                }
            }
        }
    }

    private void OnDead()
    {
        if (this.PlayerCharacterController != null)
        {
            // Disable components
            {
                // Controller
                this.PlayerCharacterController.enabled = false;

                // Camera
                Camera camera = this.GetComponentInChildren<Camera>();
                if (camera != null)
                {
                    FollowTransform cameraFollowTransform = camera.GetComponent<FollowTransform>();
                    if (cameraFollowTransform != null)
                    {
                        cameraFollowTransform.enabled = false;
                    }
                }

                // Box collider
                BoxCollider2D boxCollider2D = this.PlayerCharacterController.GetComponent<BoxCollider2D>();
                if (boxCollider2D != null)
                    boxCollider2D.enabled = false;

                // Rigidbody
                Rigidbody2D rigidbody2D = this.PlayerCharacterController.GetComponent<Rigidbody2D>();
                if (rigidbody2D != null)
                {
                    // Do not be affected by physics anymore
                    rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

                    // Reset the velocity
                    rigidbody2D.velocity = Vector2.zero;
                }
            }
        }
    }
    #endregion
}*/

