using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift_Info : MonoBehaviour
{
    [SerializeField]
    public string m_sGiftName;

    [SerializeField]
    public int m_iGiftScore;

    [SerializeField]
    public string m_sGiftInterest; 

    [SerializeField]
    Sprite m_GiftSprite; 

    public void m_SetGiftName(string giftName)
    {
        m_sGiftName = giftName;
    }

    public void m_SetGiftScore(int newScore)
    {
        switch (newScore)
        {
            case 1:
                m_iGiftScore = 100;
                break;
            case 2:
                m_iGiftScore = 75;
                break;
            case 3:
                m_iGiftScore = 50;
                break;
            case 4:
                m_iGiftScore = 25;
                break;
            default:
                m_iGiftScore = 10; 
                break;
        }
    }

    public void m_SetGiftInterest(string[] giftInterest)
    {
        foreach (var item in giftInterest)
        {
            m_sGiftInterest += item + " ";
        }
    }

    public void m_SetGiftSprite(Sprite newSprite)
    {
        m_GiftSprite = newSprite; 

        if(gameObject.GetComponent<SpriteRenderer>())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite; 
        }
    }

}

