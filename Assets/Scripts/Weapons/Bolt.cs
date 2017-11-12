using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    Rigidbody rigi;
    GameObject cBow;
    Vector3 locDirection;

    // Use this for initialization
    void Start()
    {
        cBow = GameObject.Find("Crossbow");
        rigi = gameObject.GetComponent<Rigidbody>();
        Crossbow cBowRef = cBow.GetComponent<Crossbow>();
        locDirection = cBowRef.projectileOrigin.transform.InverseTransformDirection(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        

        rigi.AddForce(locDirection * 20, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }
}
