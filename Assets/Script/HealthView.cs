using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerCharacterHealth playerCharacterHealth = null;
    public PlayerCharacterHealth PlayerCharacterHealth
    {
        get
        {
            if (this.playerCharacterHealth == null)
                this.playerCharacterHealth = this.gameObject.GetComponentInParent<PlayerCharacterHealth>();
            return this.playerCharacterHealth;
        }
    }

    [Header("Hearts")]
    [SerializeField] private List<Image> hearts = new List<Image>();

    [Header("Sprites of hearts")]
    public Sprite heartFull = null;
    public Sprite heartEmpty = null;

    void Update()
    {
        if (this.PlayerCharacterHealth != null && this.PlayerCharacterHealth.currentHealthPoints > 0 && this.PlayerCharacterHealth.maxHealthPoints > 0)
        {
            // Show
            this.Show();

            // Update
            if (this.hearts != null && this.hearts.Count > 0)
            {
                for (int i = 0; i < this.hearts.Count; i++)
                {
                    // Count hearts depending on i
                    int healthEmpty = i;
                    int healthFull = healthEmpty + 1;

                    // Full
                    if (healthFull <= this.PlayerCharacterHealth.currentHealthPoints)
                    {
                        this.hearts[i].sprite = this.heartFull;
                    }
                    else
                    {
                        this.hearts[i].sprite = this.heartEmpty;
                    }
                }
            }
        }
        else
        {
            // Hide view
            this.Hide();
        }
    }

    void Show()
    {
        if (this.hearts != null && this.hearts.Count > 0)
        {
            for (int i=0; i<this.hearts.Count; i++)
            {
                this.hearts[i].gameObject.SetActive(true);
            }
        }
    }

    void Hide()
    {
        if (this.hearts != null && this.hearts.Count > 0)
        {
            for (int i = 0; i < this.hearts.Count; i++)
            {
                this.hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
