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

    public bool m_bItemSelected; 

    bool m_bGiftSelectable;

    private void Start()
    {
        m_SelectItemButton.gameObject.SetActive(false); 
    }

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

    public GameObject m_GetItemFromSlot()
    {
        return m_ItemInSlot;
    }

    private void Update()
    {
        if(m_bGiftSelectable == false)
        {
            if(m_SelectItemButton.gameObject.activeSelf == true)
            {
                m_SelectItemButton.gameObject.SetActive(false); 
            }
        }
        else
        {
            if (m_SelectItemButton.gameObject.activeSelf == false)
            {
                m_SelectItemButton.gameObject.SetActive(true);
            }
        }
    }

    public void m_ResetItemInSlot()
    {
        m_bGiftSelectable = false;

        m_DisplayImage.sprite = null;

        m_DisplayText.text = null;

        m_ItemInSlot = null;

        m_bItemSelected = false;

        m_bSlotFree = true; 
    }

    public bool m_CheckSlotFree() => m_bSlotFree;

    public void m_ShowSelectable()
    {
        m_SelectItemButton.gameObject.SetActive(true);

        m_bGiftSelectable = true; 
    }

    public void m_HideSelectable()
    {
        m_SelectItemButton.gameObject.SetActive(true);
    }

    public void m_ItemSeleted()
    {
        m_bItemSelected = true;
    }
}
