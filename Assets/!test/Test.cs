using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test : MonoBehaviour {
    public float checkDelay = 0f;

    private float checkTimer = 0f;

    void Update()
    {
        Simulate();

        checkTimer += Time.deltaTime;
        if(checkTimer >= checkDelay)
        {
            Check();
            checkTimer = 0f;
        }
    }

    protected virtual void Simulate() { }
    protected abstract void Check();
}
