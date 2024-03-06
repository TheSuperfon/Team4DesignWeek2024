using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseCollider : MicrogameInputEvents
{
    public Transform SparkLocation;
    bool activecoroutine;
    // Start is called before the first frame update
    protected override void OnGameStart()
    {
        activecoroutine = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (activecoroutine == true)
        {
            StartCoroutine(FuseGoing());

        }
        
    }


    public IEnumerator FuseGoing()
    {
        activecoroutine = false;
        
        SparkLocation.Translate(-0.022f,0,0);
        
        yield return new WaitForSeconds(0.05f);
        
        
        activecoroutine = true;
    

        
    }

}
