using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterKeyCount : MonoBehaviour
{
    [SerializeField] private PlayerCharacterInventory playerCharacterInventory = null;
    public PlayerCharacterInventory PlayerCharacterInventory
    {
        get
        {
            if (this.playerCharacterInventory == null)
                this.playerCharacterInventory = this.gameObject.GetComponentInParent<PlayerCharacterInventory>();
            return this.playerCharacterInventory;
        }
    }

    [Header("UI References")]
    public Image keyImage = null;
    public Text keyText = null;

    void Update()
    {
        if (this.PlayerCharacterInventory != null && this.PlayerCharacterInventory.keyCount > 0)
        {
            // Show
            this.Show();

            // Update
            if (this.keyText != null)
                this.keyText.text = this.PlayerCharacterInventory.keyCount.ToString();
        }
        else
        {
            // Hide view
            this.Hide();
        }
    }

    void Show()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(true);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(true);
    }

    void Hide()
    {
        if (this.keyImage != null)
            this.keyImage.gameObject.SetActive(false);
        if (this.keyText != null)
            this.keyText.gameObject.SetActive(false);
    }
}
