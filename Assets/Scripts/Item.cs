using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _itemName, _itemDescription;
    [SerializeField] private int _quantity;
    [SerializeField] private Sprite _itemSprite;

    [SerializeField]private InventoryManager _inventoryManager;


    public void Items()
    { 
            int leftOverItems = _inventoryManager.AddItem(_itemName, _quantity,_itemSprite, _itemDescription);
            if (leftOverItems <= 0)
            { 
                Destroy(gameObject);
            }

            else
            {
                _quantity = leftOverItems;
            }
    }


}
