using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TalkToNPC : MonoBehaviour
{
    [SerializeField]
    string m_sAssignedClue = (string)("Test");

    [SerializeField]
    bool m_bPlayerWithinRange = false;

    [SerializeField]
    bool m_bInputFirstDown = false;

    [SerializeField]
    GameObject m_TalkScreen;

    #region Member Functions

    public void m_AssignClue(string newClue)
    {
        m_sAssignedClue = newClue;
    }

    public void m_AssignTalkScreen(GameObject talkScreen)
    {
        m_TalkScreen = talkScreen; 
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            m_bPlayerWithinRange = true; 
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            m_bPlayerWithinRange = false;
        }

        if (m_TalkScreen.activeSelf == true)
        {
            m_TalkScreen.SetActive(false);
        }
    }

    void Start()
    {
        if(m_TalkScreen == null)
        {
            m_TalkScreen = GameObject.FindGameObjectWithTag("Talk Screen"); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bPlayerWithinRange == true)
        {
            if (m_bInputFirstDown == false)
            {
                if (Input.GetAxis("Interact") != 0)
                {
                    Debug.Log("Player Talks");

                    m_bInputFirstDown = true; 
                }
            }

            if (m_bInputFirstDown == true && Input.GetAxis("Interact") == 0)
            {
                m_bInputFirstDown = false;
            }

            if(m_bInputFirstDown == true)
            {
                if(m_TalkScreen != null)
                {
                    m_TalkScreen.SetActive(true);

                    m_TalkScreen.GetComponentInChildren<Text>().text = m_sAssignedClue; 
                }
            }
        }
    }

    #endregion
}
