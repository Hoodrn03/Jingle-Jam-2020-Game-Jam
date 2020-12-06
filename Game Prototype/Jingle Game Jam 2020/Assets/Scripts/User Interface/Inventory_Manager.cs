using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Manager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_InventoryElements;

    private void Start()
    {
        if (m_InventoryElements.Count <= 0)
        {
            m_InventoryElements.AddRange(GameObject.FindGameObjectsWithTag("Inventory Element"));
        }
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
}
