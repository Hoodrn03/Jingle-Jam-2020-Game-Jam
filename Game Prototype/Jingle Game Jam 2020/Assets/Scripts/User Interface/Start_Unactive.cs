using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Unactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeSelf == true)
        {
            gameObject.SetActive(false); 
        }
    }

    
}
