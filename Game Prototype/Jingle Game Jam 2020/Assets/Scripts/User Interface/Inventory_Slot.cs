using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    [SerializeField]
    bool m_bSlotFree = true;

    [SerializeField]
    GameObject m_ItemInSlot;

    [SerializeField]
    Image m_DisplayImage;

    [SerializeField]
    Text m_DisplayText;

    [SerializeField]
    Button m_SelectItemButton;

    bool m_bGiftSelectable; 

    public void m_AddItemToSlot(GameObject itemToAdd)
    {
        if(m_bSlotFree == true)
        {
            Debug.Log("Item can be added.");

            m_ItemInSlot = itemToAdd;

            m_bSlotFree = false; 

            if(m_ItemInSlot.GetComponent<SpriteRenderer>())
            {
                m_DisplayImage.sprite = m_ItemInSlot.GetComponent<SpriteRenderer>().sprite; 
            }

            if (m_DisplayText != null)
            {
                m_DisplayText.text = m_ItemInSlot.name;
            }

            itemToAdd.SetActive(false);

            Debug.Log("Item " + itemToAdd.name + " has been added.");
        }
        else
        {
            Debug.Log("Slot already full with " + m_ItemInSlot.name); 
        }
    }

    public bool m_CheckSlotFree() => m_bSlotFree;
}
