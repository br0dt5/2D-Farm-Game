using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public int slotId;
    public Inventory inventory;

    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    [SerializeField] private GameObject highlight;

    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmtpy()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = string.Empty;
    }

    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }
}
