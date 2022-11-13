using UnityEngine;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour
{
    public GameObject slotPrefab;
    public const int numSlots = 5;
    Image[] itemImages = new Image[numSlots];
    ItemObject[] items = new ItemObject[numSlots];
    GameObject[] slots = new GameObject[numSlots];

    void Start()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        if(slotPrefab != null)
        {
            for(int i = 0; i < numSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;

                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);

                slots[i] = newSlot;

                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    public bool AddItem(ItemObject itemToAdd)
    {
        for(int i = 0; i < items.Length; i++)
        {
            /*if(items[i] != null && items[i].itemType == itemToAdd.itemType && itemToAdd.stackable == true)
            {
                // Adding an existing slot
                //items[i].quantity = items[i].quantity + 1;

                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();

                //Text quantityText = slotScript.qtyText;

                //quantityText.enabled = true;

                //quantityText.text = items[i].quantity.ToString();

                return true;
            }*/

            if(items[i] == null)
            {
                // Adding to empty slot
                // cpy item & add to inventory. copying so we don't change original scriptable object

                items[i] = Instantiate(itemToAdd);

                //items[i].quantity = 1;

                //itemImages[i].sprite = itemToAdd.sprite;

                itemImages[i].enabled = true;

                return true;
            }
        }

        return false;
    }
}
