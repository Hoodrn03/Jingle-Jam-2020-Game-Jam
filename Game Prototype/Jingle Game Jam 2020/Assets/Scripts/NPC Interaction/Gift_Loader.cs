using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will be a single gift within the game. It will hold a name, score and the interests involved. 
/// This will also hold the filepath for where to find the sprite, after being loaded the sprite needs
/// to be assigned. 
/// </summary>
[System.Serializable]
class Gift
{
    /// <summary>
    /// The name for the gift. 
    /// </summary>
    [SerializeField]
    public string giftName;

    /// <summary>
    /// The score for this gift. 
    /// </summary>
    [SerializeField]
    public int score;

    /// <summary>
    /// The interests accociated with this gift, (Could be more than one or none at all). 
    /// </summary>
    [SerializeField]
    public string[] interestInvolved;

    /// <summary>
    /// The file location to find the sprite for the object. 
    /// </summary>
    [SerializeField]
    public string filePath;

    /// <summary>
    ///  The sprite once it has been loaded into the game. 
    /// </summary>
    [SerializeField]
    public Sprite loadedSprite = null; 
}

/// <summary>
/// This will hold the list of gifts loaded into the game. 
/// </summary>
[System.Serializable]
class Gifts
{
    /// <summary>
    /// A list containing all gifts within the game. 
    /// </summary>
    [SerializeField]
    public List<Gift> gifts = new List<Gift>(); 
}

/// <summary>
/// This class will handle the loading and managing of all gifts within the game. 
/// </summary>
public class Gift_Loader : MonoBehaviour
{
    #region Data Members 

    /// <summary>
    /// The Json file containing all of the gifts for the game. 
    /// </summary>
    [SerializeField]
    TextAsset m_GiftJson;

    /// <summary>
    /// The currently loaded gifts within the game. 
    /// </summary>
    [SerializeField]
    Gifts m_GiftLoader;

    /// <summary>
    /// This will hold all of the gifts currently within the game. 
    /// </summary>
    [SerializeField]
    List<GameObject> m_GiftManager;

    /// <summary>
    /// A basic blank gift allowing for more to be spawned and expanded. 
    /// </summary>
    [SerializeField]
    GameObject m_BasicGift;

    [SerializeField]
    List<GameObject> m_GiftSpawnpoints; 

    [SerializeField]
    GameObject m_PlayerInventory; 



    #endregion

    #region Member Functions 

    void m_LoadGiftsIntoGame(TextAsset fileToLoad)
    {
        if(fileToLoad != null)
        {
            m_GiftLoader = JsonUtility.FromJson<Gifts>(fileToLoad.text);

            Debug.Log("Gifts loaded into game. \n");
        }
    }

    void m_LoadSpritesIntoGame()
    {
        foreach (var gift in m_GiftLoader.gifts)
        {
            if (gift.filePath.Length > 1)
            {
                gift.loadedSprite = Resources.Load<Sprite>(gift.filePath);
            }
            else
            {
                Debug.Log("Unable to load sprite " + gift.giftName + " as file path is too small"); 
            }
        }
    }

    private void Start()
    {
        m_LoadGiftsIntoGame(m_GiftJson);

        m_LoadSpritesIntoGame();
    }

    public void m_SpawnItems()
    {
        m_GiftSpawnpoints.AddRange(GameObject.FindGameObjectsWithTag("Gift Spawn Point")); 

        if (m_GiftSpawnpoints.Count > 0)
        {
            foreach (var spawnpoint in m_GiftSpawnpoints)
            {
                GameObject l_NewGift = Instantiate(m_BasicGift, spawnpoint.transform);

                Gift l_GeneratedGift = m_GiftLoader.gifts[Random.Range(0, m_GiftLoader.gifts.Count - 1)];

                l_NewGift.transform.parent = gameObject.transform;

                l_NewGift.name = l_GeneratedGift.giftName;

                if (l_NewGift.GetComponent<Gift_Info>())
                {
                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftInterest(l_GeneratedGift.interestInvolved);

                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftScore(l_GeneratedGift.score);

                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftSprite(l_GeneratedGift.loadedSprite);
                }

                m_GiftManager.Add(l_NewGift);
            }
        }
    }

    public void m_SpawnItems(GameObject parent)
    {
        m_GiftSpawnpoints.Clear(); 

        m_GiftSpawnpoints.AddRange(GameObject.FindGameObjectsWithTag("Gift Spawn Point"));

        if (m_GiftSpawnpoints.Count > 0)
        {
            foreach (var spawnpoint in m_GiftSpawnpoints)
            {
                GameObject l_NewGift = Instantiate(m_BasicGift, spawnpoint.transform);

                Gift l_GeneratedGift = m_GiftLoader.gifts[Random.Range(0, m_GiftLoader.gifts.Count - 1)];

                l_NewGift.transform.parent = parent.transform;

                l_NewGift.name = l_GeneratedGift.giftName;

                if (l_NewGift.GetComponent<Gift_Info>())
                {
                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftInterest(l_GeneratedGift.interestInvolved);

                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftScore(l_GeneratedGift.score);

                    l_NewGift.GetComponent<Gift_Info>().m_SetGiftSprite(l_GeneratedGift.loadedSprite);
                }

                m_GiftManager.Add(l_NewGift);
            }
        }
    }

    public void m_AddGiftToInventory(GameObject giftToAdd)
    {
        GameObject l_TargetInventorySlot = m_PlayerInventory.GetComponent<Inventory_Manager>().m_GetFreeSlot(); 

        if(l_TargetInventorySlot != null)
        {
            Debug.Log("Adding gift " + giftToAdd.name);

            l_TargetInventorySlot.GetComponent<Inventory_Slot>().m_AddItemToSlot(giftToAdd); 
        }
    }

    #endregion
}
