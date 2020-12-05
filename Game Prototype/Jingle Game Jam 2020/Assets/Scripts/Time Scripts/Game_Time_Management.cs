using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Time_Management : MonoBehaviour
{
    #region Data Members

    [SerializeField]
    bool m_bDayStarted = false; 

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
    float m_fTimeTillUpdate = 1;

    #endregion

    #region Member Functions 

    public void m_StartDay()
    {
        m_bDayStarted = true; 
    }

    private void Start()
    {
        // Setup variables and assign them to base values. 

        m_bDayStarted = false;
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

    #endregion
}
