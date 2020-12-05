using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will hold references to all main UI elemens which may need to be linked elsewhere. 
/// </summary>
public class Interface_Linker : MonoBehaviour
{
    #region Chat Menu Controller

    /// <summary>
    /// This is the game object which will display the NPCs clues. 
    /// </summary>
    [SerializeField]
    GameObject m_ChatMenu;

    /// <summary>
    /// This will allow access to the chat menu, this will be needed if new NPCs are spawned into the game. 
    /// </summary>
    /// <returns>The Chat Menu UI Element. </returns>
    [SerializeField]
    public GameObject m_GetChatMenu() => m_ChatMenu;

    #endregion
}
