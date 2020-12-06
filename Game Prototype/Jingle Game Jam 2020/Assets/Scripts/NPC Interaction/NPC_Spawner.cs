using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> m_NpcSpawnPoints;

    [SerializeField]
    List<GameObject> m_NPCList;

    [SerializeField]
    GameObject m_PrefabNpc;

    [Header("Manager Objects")]

    [SerializeField]
    public GameObject m_InterfaceLinker; 

    [SerializeField]
    public GameObject m_NPCManager;


    void Start()
    {
        if(m_InterfaceLinker == null)
        {
            m_InterfaceLinker = GameObject.FindGameObjectWithTag("User Interface"); 
        }

        
    }

    public void m_SpawnNPCs()
    {
        if (m_NpcSpawnPoints.Count > 0)
        {
            for (int i = 0; i < m_NpcSpawnPoints.Count; i++)
            {
                GameObject l_NewNPC = Instantiate(m_PrefabNpc, m_NpcSpawnPoints[i].transform);

                l_NewNPC.name = m_NPCManager.GetComponent<NPC_Controller_Script>().m_GenerateRandomName();

                l_NewNPC.GetComponent<TalkToNPC>().m_AssignSprite(m_NPCManager.GetComponent<NPC_Controller_Script>().m_GetRandomSprite()); 

                l_NewNPC.GetComponent<TalkToNPC>().m_AssignClue(m_NPCManager.GetComponent<NPC_Controller_Script>().m_GenerateClue());

                l_NewNPC.GetComponent<TalkToNPC>().m_AssignTalkScreen(m_InterfaceLinker.GetComponent<Interface_Linker>().m_GetChatMenu());

                l_NewNPC.transform.parent = gameObject.transform;

                m_NPCList.Add(l_NewNPC);
            }
        }
    }

}
