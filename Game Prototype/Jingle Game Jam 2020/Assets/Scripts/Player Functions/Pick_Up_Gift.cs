using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up_Gift : MonoBehaviour
{
    [SerializeField]
    bool m_bPlayerTouchingGift = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player has touched a gift");

            m_bPlayerTouchingGift = true;

            gameObject.GetComponentInParent<Gift_Loader>().m_AddGiftToInventory(gameObject); 
        }
    }
}
