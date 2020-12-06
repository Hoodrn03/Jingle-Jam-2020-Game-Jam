using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Gift : MonoBehaviour
{
    [SerializeField]
    bool m_bPlayerTouchingGift = false;

    [SerializeField]
    GameObject m_GiftManager;

    private void Start()
    {
        m_GiftManager = GameObject.FindGameObjectWithTag("Gift Manager"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player has touched a gift");

            m_bPlayerTouchingGift = true;

            m_GiftManager.GetComponent<Gift_Loader>().m_AddGiftToInventory(gameObject); 
        }
    }
}
