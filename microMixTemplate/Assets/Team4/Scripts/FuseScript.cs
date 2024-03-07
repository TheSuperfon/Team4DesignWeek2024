using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseScript : MicrogameInputEvents
{
    public Transform SparkLocation;
    public Transform Endfuse;
    bool activecoroutine;
    LineRenderer Fuse;
    public float fusetime;
    public GameObject explosionimage;
    bool Notagain;




    // Start is called before the first frame update
    protected override void OnGameStart()
    {
        Fuse = GetComponent<LineRenderer>();
        Fuse.positionCount = 2;
        Fuse.SetPosition(0, new Vector2(SparkLocation.position.x, SparkLocation.position.y));
        Fuse.SetPosition(1, new Vector2(Endfuse.position.x, Endfuse.position.y));
        activecoroutine = true;
        explosionimage.SetActive(false);
        Notagain = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((activecoroutine == true) && (Notagain == false))
        {
            StartCoroutine(LitBomb());

        }
        
        
        
        
    }

    public IEnumerator LitBomb()
    {
        activecoroutine = false;
        
        if (SparkLocation.position.x >= Endfuse.position.x)
        {
            SparkLocation.Translate (-fusetime, 0, 0);
            //Debug.Log("test");
            Fuse.SetPosition(0, new Vector2(SparkLocation.position.x, SparkLocation.position.y));
            yield return new WaitForSeconds(0.05f);
        }
        else{
            explosionimage.SetActive(true);
            //Debug.Log("finish");
            Notagain = true;
            ReportGameCompletedEarly();
            //Debug.Log("finish2");
        }
        
        activecoroutine = true;

    }


    void Newspark()
    {
        
    }


}
