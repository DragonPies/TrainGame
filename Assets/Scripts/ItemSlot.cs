using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    [Header("Item Data")]
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField] private int maxQuantity = 99; // Maximum quantity for the item slot

    [Header("Item Slot")]
    [SerializeField] private TMP_Text _quantityText;
    [SerializeField] private Image _itemImage;

    [Header("Item Description Slot")]
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionName,itemDescriptionText;


    public GameObject selectedShader;
    public bool isSelected;

    public InventoryManager _inventoryManager;

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        if (isFull)
        { 
            return quantity; // Return the number of items that couldn't be added
        }


        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.quantity += quantity;

        this.itemDescription = itemDescription;
        _itemImage.sprite = itemSprite;

        if (this.quantity >= maxQuantity)
        {
            _quantityText.text = maxQuantity.ToString();
            _quantityText.enabled = true;
            isFull = true;

            int extraItems = this.quantity - maxQuantity;
            this.quantity = maxQuantity;
            return extraItems; // Return the number of items that couldn't be added
        }

        _quantityText.text = this.quantity.ToString();
        _quantityText.enabled = true;
        return 0; // All items were added successfully



    }

    public void OnPointerClick(PointerEventData eventData)
    { 
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
       
    }

    public void OnLeftClick()
    {
        Debug.Log($"Left clicked on {itemName} slot.");
        // Implement left click behavior here
        
        _inventoryManager.DeSelectAllSlots();
        selectedShader.SetActive(true);
        this.isSelected = true;
        itemDescriptionImage.sprite = itemSprite;
        itemDescriptionName.text = itemName;
        itemDescriptionText.text = itemDescription;
        if (itemDescriptionImage.sprite == null)
        { 
            itemDescriptionImage.sprite = emptySprite;
        }
    }
    public void OnRightClick()
    {
        Debug.Log($"Right clicked on {itemName} slot.");
        // Implement right click behavior here
    }
}
