using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<SlotUI> slots = new List<SlotUI>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != string.Empty)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmtpy();
                }
            }
        }
    }

    public void Remove(int slotId)
    {
        Item item = GameManager.instance.itemManager.GetItemByName(player.inventory.slots[slotId].itemName);

        if (item != null)
        {
            player.DropItem(item);
            player.inventory.Remove(slotId);
            Refresh();
        }
    }
}
