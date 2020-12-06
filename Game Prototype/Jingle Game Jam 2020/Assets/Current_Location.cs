using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MapData
{
    [SerializeField]
    public string l_sMapName;

    [SerializeField]
    public GameObject l_MapPrefab;

    [SerializeField]
    public GameObject l_LoadedMap; 
}

public class Current_Location : MonoBehaviour
{
    [SerializeField]
    MapData m_CurrentLocation;

    [SerializeField]
    List<MapData> m_Maps;

    [Header("Managers.")]

    [SerializeField]
    GameObject m_GiftManager;

    [SerializeField]
    GameObject m_NPCManager;

    [SerializeField]
    GameObject m_InterfaceLinker;

    [SerializeField]
    GameObject m_Player;

    [SerializeField]
    List<string> m_MapNames;

    [Header("Map Prefabs")]

    [SerializeField]
    GameObject m_TempMap;

    public void m_LoadLevel(string mapName)
    {
        for (int i = 0; i < m_Maps.Count; i++)
        {
            if(m_Maps[i].l_sMapName == mapName)
            {
                m_Player.SetActive(true); 

                m_CurrentLocation = m_Maps[i]; 

                if(m_CurrentLocation.l_LoadedMap == null)
                {
                    m_CurrentLocation.l_LoadedMap = Instantiate(m_CurrentLocation.l_MapPrefab);

                    m_CurrentLocation.l_LoadedMap.transform.parent = gameObject.transform; 

                    m_GiftManager.GetComponent<Gift_Loader>().m_SpawnItems(m_CurrentLocation.l_LoadedMap);

                    m_CurrentLocation.l_LoadedMap.GetComponentInChildren<NPC_Spawner>().m_NPCManager = m_NPCManager;

                    m_CurrentLocation.l_LoadedMap.GetComponentInChildren<NPC_Spawner>().m_InterfaceLinker = m_InterfaceLinker;

                    m_CurrentLocation.l_LoadedMap.GetComponentInChildren<NPC_Spawner>().m_SpawnNPCs(); 

                    if (m_Player.activeSelf == false)
                    {
                        m_Player.SetActive(true);
                    }

                    m_CurrentLocation.l_LoadedMap.GetComponent<Player_Spawn>().m_SpawnPlayer(m_Player); 

                    m_Maps[i] = m_CurrentLocation; 
                }
                else
                {
                    m_CurrentLocation.l_LoadedMap.SetActive(true);

                    if (m_Player.activeSelf == false)
                    {
                        m_Player.SetActive(true);
                    }

                    m_CurrentLocation.l_LoadedMap.GetComponent<Player_Spawn>().m_SpawnPlayer(m_Player);
                }
            }
        }
    }

    public void m_ExitLocation()
    {
        foreach (var map in m_Maps)
        {
            if (map.l_LoadedMap != null)
            {
                if (map.l_sMapName != m_CurrentLocation.l_sMapName)
                {
                    map.l_LoadedMap.SetActive(false);
                }
                else
                {
                    if (map.l_LoadedMap.activeSelf != true)
                    {
                        map.l_LoadedMap.SetActive(true);
                    }
                }
            }
        } 
    }

    public void m_ClearMaps()
    {
        foreach (var map in m_Maps)
        {
            Destroy(map.l_LoadedMap); 
        }

        m_Maps.Clear(); 

        m_Maps = new List<MapData>();

        foreach (var name in m_MapNames)
        {
            MapData l_TempData = new MapData();

            l_TempData.l_sMapName = name;

            switch (l_TempData.l_sMapName)
            {
                default:
                    l_TempData.l_MapPrefab = m_TempMap; 
                    break;
            }

            m_Maps.Add(l_TempData); 
        }
    }
}
