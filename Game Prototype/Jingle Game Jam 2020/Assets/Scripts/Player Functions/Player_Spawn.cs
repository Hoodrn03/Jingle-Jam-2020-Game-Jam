using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject m_PlayerSpawnPoint; 

    [SerializeField]
    GameObject m_PlayerObj; 

    void Start()
    {
        m_PlayerObj = GameObject.FindGameObjectWithTag("Player");

        m_SpawnPlayer();
    }

    public void m_SpawnPlayer()
    {
        m_PlayerSpawnPoint = GameObject.FindGameObjectWithTag("Player Spawn Point");

        if (m_PlayerSpawnPoint != null)
        {
            m_PlayerObj.transform.position = m_PlayerSpawnPoint.transform.position; 
        }
    }
}
