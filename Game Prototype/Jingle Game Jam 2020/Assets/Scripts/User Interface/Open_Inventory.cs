using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Inventory : MonoBehaviour
{

    [SerializeField]
    GameObject m_InventoryObject;

    bool m_bFirstPress = false; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Inventory") != 0)
        {
            if (m_bFirstPress == false)
            {
                if (m_InventoryObject.activeSelf == false)
                {
                    m_InventoryObject.SetActive(true);

                    m_bFirstPress = true;
                }
                else
                {
                    m_InventoryObject.SetActive(false);

                    m_bFirstPress = true;
                }
            }
        }
        else
        {
            m_bFirstPress = false; 
        }
    }
}
