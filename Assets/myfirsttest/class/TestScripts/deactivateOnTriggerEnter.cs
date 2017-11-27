using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateOnTriggerEnter : MonoBehaviour
{
    void OnTriggerEnter()
    {
        gameObject.SetActive(false);
    }
}
