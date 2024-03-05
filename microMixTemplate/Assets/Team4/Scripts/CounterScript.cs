using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{

    public bool vCounter = false;
    public float timeElapsed;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        {
            vCounter = true;
            Debug.Log("V Pressed!");
        }
        else
        {
            vCounter = false;
        }
    }
}
