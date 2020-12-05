using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Navigation : MonoBehaviour
{
    #region Data Members

    [SerializeField]
    GameObject m_MainMenu;

    [SerializeField]
    GameObject m_OptionsMenu;

    [SerializeField]
    GameObject m_CreditsMenu;

    #endregion

    #region Member Functions

    private void Start()
    {
        if(m_MainMenu != null)
        {
            if(m_MainMenu.activeSelf == false)
            {
                m_MainMenu.SetActive(true);
            }
        }

        if (m_OptionsMenu != null)
        {
            if (m_OptionsMenu.activeSelf == true)
            {
                m_OptionsMenu.SetActive(false);
            }
        }

        if (m_CreditsMenu != null)
        {
            if (m_CreditsMenu.activeSelf == true)
            {
                m_CreditsMenu.SetActive(false);
            }
        }
    }

    public void m_EndGame()
    {
        Application.Quit();

        Debug.LogError("Game Closed - Still open due to editor."); 
    }

    #endregion
}
