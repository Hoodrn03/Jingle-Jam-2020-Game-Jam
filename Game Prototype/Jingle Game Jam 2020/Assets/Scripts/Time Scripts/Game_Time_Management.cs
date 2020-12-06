using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Time_Management : MonoBehaviour
{
    #region Data Members

    [SerializeField]
    bool m_bDayStarted = false;

    [SerializeField]
    int m_INumberOfDays = 7;

    [SerializeField]
    int m_CurrentDay = 0; 

    /// <summary>
    /// This will be used to track the time before the clock is ammended. 
    /// </summary>
    [SerializeField]
    float m_fTimeCounter = 0;

    /// <summary>
    /// This is the current time within the game, once it reaches 100, the player will have used up their 
    /// full day. 
    /// </summary>
    [SerializeField]
    float m_CurrentTime = 0;

    /// <summary>
    /// This will be the time it takes before an update tick occurs. It will change how long the day will be. 
    /// </summary>
    [SerializeField]
    [Range(1, 10)]
    float m_fTimeTillUpdate = 3;

    [SerializeField]
    GameObject m_EndScreen;

    #endregion

    #region Member Functions 

    public void m_ResetTime()
    {
        m_CurrentDay = 0; 
    }

    private void Update()
    {
        if (m_bDayStarted)
        {
            // Ammend the current time

            m_fTimeCounter += Time.deltaTime;

            if (m_fTimeCounter >= m_fTimeTillUpdate)
            {
                m_CurrentTime++;

                m_fTimeCounter = 0;

                
            }
        }
    }

    public int m_GetCurrentDay()
    {
        return m_INumberOfDays - m_CurrentDay; 
    }

    public void m_NextDay()
    {
        m_CurrentDay++;

        if(m_CurrentDay >= m_INumberOfDays)
        {
            m_EndScreen.GetComponent<Get_Score>().m_ShowEndScreen(); 
        }
    }

    #endregion
}
