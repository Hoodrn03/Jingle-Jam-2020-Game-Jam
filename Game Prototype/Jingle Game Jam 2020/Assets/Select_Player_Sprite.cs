using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Select_Player_Sprite : MonoBehaviour
{
    [SerializeField]
    Image m_CurrentSprite;

    [SerializeField]
    List<Sprite> m_PlayerSprites;

    [SerializeField]
    bool m_bFirstOpen; 

    public void m_SelectSprite()
    {
        m_CurrentSprite.sprite = m_PlayerSprites[Random.Range(0, m_PlayerSprites.Count - 1)];
    }
}
