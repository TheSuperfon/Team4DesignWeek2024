using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team04
{
	public class FuseScript : MicrogameInputEvents
{
    public Transform SparkLocation;
    public Transform Endfuse;
    public bool activecoroutine;
    LineRenderer Fuse;
    public float fusetime;
    public GameObject explosionimage;
    bool Notagain;
    public GameObject RoadRunnerAsh;
    public GameObject Foxash;
    public GameObject jerboaAsh;
    public GameObject RoadRunner;
    public GameObject Fox;
    public GameObject jerboa;
    public GameObject Music;
    public SpriteRenderer RealSpark;
    public SpriteRenderer otherspark;
    public SpriteRenderer bombsprite;
    public SpriteRenderer bluebombsprite;
    public SpriteRenderer endrope;



    // Start is called before the first frame update
    protected override void OnGameStart()
    {
        RoadRunnerAsh.SetActive(false);
        Foxash.SetActive(false);
        jerboaAsh.SetActive(false);
        RoadRunner.SetActive(true);
        Fox.SetActive(true);
        jerboa.SetActive(true);
        Fuse = GetComponent<LineRenderer>();
        Fuse.positionCount = 2;
        Fuse.SetPosition(0, new Vector2(SparkLocation.position.x, SparkLocation.position.y));
        Fuse.SetPosition(1, new Vector2(Endfuse.position.x, Endfuse.position.y));
        activecoroutine = true;
        explosionimage.SetActive(false);
        Notagain = false;
        Music.SetActive(true);
        RealSpark.enabled = true;
        otherspark.enabled = true;
        bombsprite.enabled = true;
        bluebombsprite.enabled = true;
        endrope.enabled = true;
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
            RoadRunnerAsh.SetActive(true);
            Foxash.SetActive(true);
            jerboaAsh.SetActive(true);
            RoadRunner.SetActive(false);
            Fox.SetActive(false);
            jerboa.SetActive(false);
            Music.SetActive(false);
            RealSpark.enabled = false;
            otherspark.enabled = false;
            bombsprite.enabled = false;
            bluebombsprite.enabled = false;
            endrope.enabled = false;
            //Debug.Log("finish");
            Notagain = true;
            ReportGameCompletedEarly();
            //Debug.Log("finish2");
        }
        
        activecoroutine = true;

    }


    


}



}
