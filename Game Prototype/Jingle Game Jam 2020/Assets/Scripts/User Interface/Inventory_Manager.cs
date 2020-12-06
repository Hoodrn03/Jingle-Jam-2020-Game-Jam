using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    [Header("Inventory Elements.")]

    [SerializeField]
    List<GameObject> m_InventoryElements;

    [Header("Other.")]

    [SerializeField]
    GameObject m_Backbutton;

    [SerializeField]
    GameObject m_SelectedGift = null;

    bool m_bInvetorySelectable; 

    private void Start()
    {
        if (m_InventoryElements.Count <= 0)
        {
            m_InventoryElements.AddRange(GameObject.FindGameObjectsWithTag("Inventory Element"));
        }

        m_Backbutton.SetActive(false); 
    }

    public void m_ClearInventory()
    {
        foreach (var slot in m_InventoryElements)
        {
            slot.GetComponent<Inventory_Slot>().m_ResetItemInSlot(); 
        }
    }

    private void Update()
    {
        if(m_bInvetorySelectable == true)
        {
            if(m_Backbutton.activeSelf == false)
            {
                m_Backbutton.SetActive(true); 
            }
        }
        else
        {
            if (m_Backbutton.activeSelf == true)
            {
                m_Backbutton.SetActive(false);
            }
        }

        foreach (var gift in m_InventoryElements)
        {
            if(gift.GetComponent<Inventory_Slot>().m_bItemSelected)
            {
                if (gift.GetComponent<Inventory_Slot>().m_GetItemFromSlot() != null)
                {
                    m_SelectedGift = gift.GetComponent<Inventory_Slot>().m_GetItemFromSlot();

                    if (m_SelectedGift != null)
                    {
                        Debug.Log(m_SelectedGift.name);

                        gift.GetComponent<Inventory_Slot>().m_ResetItemInSlot();
                    }
                }
            }
        }
    }

    public GameObject m_GetSelectedGift() => m_SelectedGift; 

    public void m_ResetSelectedGift()
    {
        m_SelectedGift = null;
    }

    public GameObject m_GetFreeSlot()
    {
        GameObject l_InventorySlot = null;

        foreach (var inventorySlot in m_InventoryElements)
        {
            if(inventorySlot.GetComponent<Inventory_Slot>().m_CheckSlotFree())
            {
                l_InventorySlot = inventorySlot;

                break;
            }
        }

        if(l_InventorySlot == null)
        {
            Debug.Log("Inventory full"); 
        }

        return l_InventorySlot; 
    }

    public void m_SetGiftSelectable()
    {
        foreach (var element in m_InventoryElements)
        {
            element.GetComponent<Inventory_Slot>().m_ShowSelectable(); 
        }

        m_Backbutton.SetActive(true); 
    }

    public void m_SetInventorySelectable(bool newValue)
    {
        m_bInvetorySelectable = newValue; 
    }
}
