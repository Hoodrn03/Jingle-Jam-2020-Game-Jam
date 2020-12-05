using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Data Structs 

/// <summary>
/// This is a generated person who will be given to the player at the start of the game. 
/// </summary>
[System.Serializable]
struct TargetPerson
{
    /// <summary>
    /// This is the first name of the person. 
    /// </summary>
    [SerializeField]
    public string l_sFirstName;

    /// <summary>
    /// This is teh last name of the person.
    /// </summary>
    [SerializeField]
    public string l_LastName;

    /// <summary>
    /// This is the person's main interest. 
    /// </summary>
    [SerializeField]
    public Interest l_Interest; 
}

#endregion

#region Loading Classes 

/// <summary>
/// This is a list of names to be loaded into the game, this will contain both first and last names. 
/// </summary>
[System.Serializable]
class Names
{
    /// <summary>
    /// The start of a name. 
    /// </summary>
    [SerializeField]
    public string[] firstNames;

    /// <summary>
    /// The end of a name. 
    /// </summary>
    [SerializeField]
    public string[] lastNames; 
}

/// <summary>
/// This is a possible interest a person could have. It will also a list of clues accociated with that interest. 
/// </summary>
[System.Serializable]
class Interest
{
    /// <summary>
    /// The name of the interest. 
    /// </summary>
    [SerializeField]
    public string interestName;

    /// <summary>
    /// The clues for the interest. 
    /// </summary>
    [SerializeField]
    public string[] clues; 
}

/// <summary>
/// The list of all of the interests within the game. 
/// </summary>
[System.Serializable]
class Interests
{
    /// <summary>
    /// The list containing all loaded interests within the game. 
    /// </summary>
    [SerializeField]
    public List<Interest> interests = new List<Interest>(); 
}

#endregion

/// <summary>
/// This class is the main controller for the NPCs, its main job will be to create the target person, assign clues 
/// and load all of the text elelments at the start of the game. 
/// </summary>
public class NPC_Controller_Script : MonoBehaviour
{
    #region Data Members 

    #region Data Storing/Management

    [Header("Loaded Data")]

    /// <summary>
    /// This will hold a list of first and last names to be used by the game. 
    /// </summary>
    [SerializeField]
    Names m_NameLoader;

    /// <summary>
    /// This will load the list of interests within the game at the start of the game. 
    /// </summary>
    [SerializeField]
    Interests m_InteretsLoader; 

    #endregion

    #region Text Assets

    [Header("Json Files")]

    /// <summary>
    /// This file will hold a list of first and last names to be loaded into the game upon startup. 
    /// </summary>
    [SerializeField]
    TextAsset m_NameJson;

    /// <summary>
    ///  This file will hold all of the interests within the game with a list of possible clues for that interest. 
    /// </summary>
    [SerializeField]
    TextAsset m_InterestsJson;

    #endregion

    [Header("Target")]

    /// <summary>
    /// This is the person to be generated and given to the player at the start of the game. 
    /// </summary>
    [SerializeField]
    TargetPerson m_TargetPerson;

    #endregion

    #region Member Functions 

    #region Json Loading

    #region Names

    /// <summary>
    /// This will load the names into the game when called. 
    /// </summary>
    /// <param name="filePath">The static file path to the list of interests. </param>
    private void m_LoadNamesIntoGame(string filePath)
    {
        TextAsset l_FoundFile = Resources.Load<TextAsset>(filePath); 

        if(l_FoundFile != null)
        {
            m_NameLoader = JsonUtility.FromJson<Names>(l_FoundFile.text);

            Debug.Log("Names loaded into game. \n");
        }
        else
        {
            Debug.LogError("Unable to find file at " + filePath);
        }

    }

    /// <summary>
    /// This will load the names into the game when called. 
    /// </summary>
    /// <param name="filePath">The file conataining all of the information. </param>
    private void m_LoadNamesIntoGame(TextAsset fileToLoad)
    {
        m_NameLoader = JsonUtility.FromJson<Names>(fileToLoad.text);

        Debug.Log("Names loaded into game. \n");
    }

    #endregion

    #region Interests

    /// <summary>
    /// This will load the interests into the game when called. 
    /// </summary>
    /// <param name="filePath">The static file path to the list of interests. </param>
    private void m_LoadInterestsIntoGame(string filePath)
    {
        TextAsset l_FoundFile = Resources.Load<TextAsset>(filePath);

        if (l_FoundFile != null)
        {
            m_InteretsLoader = JsonUtility.FromJson<Interests>(l_FoundFile.text);

            Debug.Log("Interests loaded into game. \n");
        }
        else
        {
            Debug.LogError("Unable to find file at " + filePath);
        }

    }

    /// <summary>
    /// This will load the interests into the game when called. 
    /// </summary>
    /// <param name="filePath">The file conataining all of the information. </param>
    private void m_LoadInterestsIntoGame(TextAsset fileToLoad)
    {
        m_InteretsLoader = JsonUtility.FromJson<Interests>(fileToLoad.text);

        Debug.Log("Interests loaded into game. \n");
    }

    #endregion

    #endregion

    #region Target Person Management

    void m_GenerateTaretPerson()
    {
        int l_iMaxNumber = 0;

        // Generate first name. 

        l_iMaxNumber = m_NameLoader.firstNames.Length;

        m_TargetPerson.l_sFirstName = m_NameLoader.firstNames[Random.Range(0, l_iMaxNumber)];

        // Generate last name. 

        l_iMaxNumber = m_NameLoader.lastNames.Length;

        m_TargetPerson.l_LastName = m_NameLoader.lastNames[Random.Range(0, l_iMaxNumber)];

        // Add interest. 

        l_iMaxNumber = m_InteretsLoader.interests.Count;

        m_TargetPerson.l_Interest = m_InteretsLoader.interests[Random.Range(0, l_iMaxNumber)];
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // Load data from Json files to store locally. 

        m_LoadNamesIntoGame(m_NameJson);

        m_LoadInterestsIntoGame(m_InterestsJson);

        // Generate Target person

        m_GenerateTaretPerson(); 

    }

    public string m_GenerateRandomName()
    {

        string l_sReturnName = ""; 

        // Generate first name. 

        l_sReturnName += m_NameLoader.firstNames[Random.Range(0, m_NameLoader.firstNames.Length)];

        // Generate last name. 

        l_sReturnName += m_NameLoader.lastNames[Random.Range(0, m_NameLoader.lastNames.Length)];

        return l_sReturnName;
    }

    public string m_GenerateClue()
    {
        string l_sReturnClue = "";

        if(Random.Range(0, 100) <= 80)
        {
            // Tell Truth 

            l_sReturnClue = m_TargetPerson.l_Interest.clues[Random.Range(0, m_TargetPerson.l_Interest.clues.Length)];

            l_sReturnClue = l_sReturnClue.Replace("X", m_TargetPerson.l_sFirstName);

        }
        else
        {
            Debug.Log("Someone is lying"); 

            // Tell Lie

            int l_iRandomInterest = Random.Range(0, m_InteretsLoader.interests.Count - 1);

            l_sReturnClue = m_InteretsLoader.interests[l_iRandomInterest].clues[m_InteretsLoader.interests[l_iRandomInterest].clues.Length - 1];

            l_sReturnClue = l_sReturnClue.Replace("X", m_TargetPerson.l_sFirstName);
        }

        return l_sReturnClue; 
    }

    #endregion

}
