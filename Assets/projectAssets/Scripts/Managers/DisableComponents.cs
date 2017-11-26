using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableComponents : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer) // Disable all components if they are not the local player
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }

        }
        
    }

    
}
