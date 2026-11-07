using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    private bool isInventoryOpen = false;
    [SerializeField]private CameraScript _cameraScript;

    public ItemSlot[] itemSlots;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleInventory(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        if (isInventoryOpen)
        {
            inventoryMenu.SetActive(false);
            isInventoryOpen = false;
            Time.timeScale = 1f; // Resume the game
            _cameraScript.isCameraOn = true; // Enable camera movement
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        }
        else
        {
            inventoryMenu.SetActive(true);
            isInventoryOpen = true;
            Time.timeScale = 0f; // Pause the game
            _cameraScript.isCameraOn = false; // Disable camera movement
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log($"Added {quantity} of {itemName} to inventory.");
        
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull && itemSlots[i].itemName == itemName || itemSlots[i].quantity == 0)
            {
                int leftoOverItems = itemSlots[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftoOverItems > 0)
                { 
                    leftoOverItems = AddItem(itemName, leftoOverItems, itemSprite, itemDescription);
                }
                return leftoOverItems;
            }
        }
        return quantity; // Return the number of items that couldn't be added

    }

    public void DeSelectAllSlots()
    { 
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].isSelected = false;
        }
    }
}
