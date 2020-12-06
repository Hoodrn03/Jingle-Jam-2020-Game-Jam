using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_Person_Info : MonoBehaviour
{
    #region Data Members

    [Header("Target Person.")]

    [SerializeField]
    string m_TargetPersonName;

    [SerializeField]
    string m_TargetPersonInterest;

    [SerializeField]
    int m_iScore;

    [Header("Text Elements")]

    [SerializeField]
    Text m_DisplayText;

    [SerializeField]
    Text m_ScoreText;

    [SerializeField]
    Text m_DayCounterText;

    [Header("Managers.")]

    [SerializeField]
    GameObject m_NPCManager;

    [SerializeField]
    GameObject m_InventoryManager;

    [SerializeField]
    GameObject m_TimeManager;

    #endregion

    #region Member Functions 

    public void m_SetTargetPersonInfo(string name, string interest)
    {
        m_TargetPersonName = name;

        m_TargetPersonInterest = interest;
    }

    public void m_UpdateText()
    {
        string l_sBaseText = "You are gifting for ";

        m_DisplayText.text = l_sBaseText + m_TargetPersonName; 
    }

    public void m_UpdateScoreText()
    {
        string l_sBaseText = "You have X points.";

        m_ScoreText.text = l_sBaseText.Replace("X", m_iScore.ToString());
    }

    public void m_UpdateTimeText()
    {
        string l_sBaseText = "You have X days till Christmas.";

        m_DayCounterText.text = l_sBaseText.Replace("X", m_TimeManager.GetComponent<Game_Time_Management>().m_GetCurrentDay().ToString());
    }

    public void m_GiveGift(GameObject gift)
    {
        if(gift.GetComponent<Gift_Info>())
        {
            if (gift.GetComponent<Gift_Info>().m_sGiftInterest.Contains(m_TargetPersonInterest))
            {
                m_iScore += gift.GetComponent<Gift_Info>().m_iGiftScore * 2; 
            }
            else
            {
                m_iScore += gift.GetComponent<Gift_Info>().m_iGiftScore / 2; 
            }
        }

        m_UpdateScoreText(); 
    }

    public void m_resetTargetPerson()
    {
        m_TargetPersonName = "";

        m_UpdateText();

        m_UpdateTimeText();
    }

    private void Update()
    {
        if(m_TargetPersonName == "")
        {
            m_TargetPersonName = m_NPCManager.GetComponent<NPC_Controller_Script>().m_GetTargetPerson().l_sFirstName + " " +
                m_NPCManager.GetComponent<NPC_Controller_Script>().m_GetTargetPerson().l_LastName;

            m_UpdateText();

            m_UpdateTimeText();
        }

        if (m_TargetPersonInterest == "")
        {
            m_TargetPersonInterest += m_NPCManager.GetComponent<NPC_Controller_Script>().m_GetTargetPerson().l_Interest.interestName;
        }

        if(m_InventoryManager.GetComponent<Inventory_Manager>().m_GetSelectedGift() != null)
        {
            m_GiveGift(m_InventoryManager.GetComponent<Inventory_Manager>().m_GetSelectedGift());

            m_InventoryManager.GetComponent<Inventory_Manager>().m_ResetSelectedGift(); 
        }
    }

    #endregion

}
