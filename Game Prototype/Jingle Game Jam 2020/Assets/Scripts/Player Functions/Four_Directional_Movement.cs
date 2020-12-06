using UnityEngine;

/// <summary>
/// This will allow for the player to move in four directions within the game. 
/// </summary>
public class Four_Directional_Movement : MonoBehaviour
{
    #region Data Members 

    /// <summary>
    /// This will be the intended movement speed for the player object within the game. 
    /// </summary>
    [SerializeField]
    [Range(0.001f, 10f)]
    float m_fMovementSpeed = 0.25f;

    [SerializeField]
    bool m_bCollided = false;

    #endregion

    #region Member Functions 

    // Update is called once per frame
    void Update()
    {
        // Prep Variables 

        float l_fX, l_fY;

        // Move Left and right.  

        l_fX = Input.GetAxis("Horizontal") * m_fMovementSpeed * Time.deltaTime;

        // Move Up and Down. 

        l_fY = Input.GetAxis("Vertical") * m_fMovementSpeed * Time.deltaTime;

        // Apply movement.

        gameObject.transform.position = gameObject.transform.position + new Vector3(l_fX, l_fY, 0); 
    }

    

    #endregion
}
