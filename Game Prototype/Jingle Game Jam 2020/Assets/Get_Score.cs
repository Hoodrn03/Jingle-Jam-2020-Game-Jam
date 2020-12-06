using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_Score : MonoBehaviour
{
    [SerializeField]
    GameObject m_ScoreObject;

    [SerializeField]
    Text m_ScoreDisplay;

    [SerializeField]
    List<GameObject> MenusToClose;

    string m_sBaseText = "You scored X points, Well Done!";

    public void m_ShowEndScreen()
    {
        transform.parent.gameObject.SetActive(true);

        m_ScoreDisplay.text = m_sBaseText.Replace("X", m_ScoreObject.GetComponent<Target_Person_Info>().m_iScore.ToString());

        foreach (var menu in MenusToClose)
        {
            menu.SetActive(false);
        }
    }

    private void Start()
    {
        m_ScoreDisplay.text = m_sBaseText.Replace("X", m_ScoreObject.GetComponent<Target_Person_Info>().m_iScore.ToString());

        foreach (var menu in MenusToClose)
        {
            menu.SetActive(false); 
        }
    }

}
