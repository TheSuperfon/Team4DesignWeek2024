using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CounterScript : MicrogameInputEvents
{
    public bool Vactive;
    public bool vCounter;
    public float timeElapsed;
    public GameObject bomb;
    public Transform SparkLocation;
    public Transform Ropelocation;
    //public GameObject Rope;
    public GameObject heatmark;
    public LineRenderer Fuse;
    public float Realscore;
    public GameObject Winscore;
    public GameObject RopeParticleSpawn;
    public Transform RopeParticleTransform;
    public GameObject musicPlay;
    bool endgame;
    public KnifeScript TheKnifeScript;
    public GameObject Music;

    

    protected override void OnGameStart()
    {
        vCounter = true;
        Vactive = false;
        timeElapsed = 0;
        Winscore.SetActive(false);
        heatmark.SetActive(false);
        RopeParticleSpawn.SetActive(false);
        musicPlay.SetActive(false);
        endgame = false;
        
        
    }

    // Update is called once per frame
    private void Update()
    {


        //if (button1.IsPressed) 
        //{
        //    //vCounter = true;
        //    Debug.Log("V Pressed!");
        //}
        //else
        //{
        //    //vCounter = false;
        //}
        if (Realscore >= 15)
        {
            Vactive = false;
            bomb.SetActive(false);
            heatmark.SetActive(false);
            Winscore.SetActive(true);
            Music.SetActive(false);
            //Debug.Log("finish");
            
            if (endgame == true)
            {
                endgame = false;
                ReportGameCompletedEarly();
                //Debug.Log("done");
                
            }
            
            //Debug.Log("finish2");
            
        }

        if (button1.IsPressed()) {
            TheKnifeScript.KnifeMoveActive = false;
        // Similar to Input.GetButton("Button 1") in the old system.
        //Debug.Log("held");
        //button1Held = true;

        //} else {

        //button1Held = false;

        }
        else{
            TheKnifeScript.KnifeMoveActive = true;

        }

        
    }

    protected override void OnButton1Pressed(InputAction.CallbackContext context) 
    {
        if (Vactive == false) return;
        //Debug.Log("V Pressed!");
        timeElapsed += 1;
        StartCoroutine(Vtimer());
        endgame = true;


        if (timeElapsed >= 5) 
        {
            
            Vector2 NewHeatmarkLocation = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            heatmark.transform.position = NewHeatmarkLocation;
            heatmark.SetActive(true);
            
            
        }
        else{
            heatmark.SetActive(false);
            ropeparticles();
        }
        
    }


    public IEnumerator Vtimer()
    {
        //if (Vactive == false) return;
        //Debug.Log(timeElapsed);
        if (vCounter == true)
        {
            vCounter = false;
            yield return new WaitForSeconds(3f);
            Vresults();
            vCounter = true;
        }
        
        //Debug.Log("new");
        
    

        
    }

    public void ropeparticles()
    {
        //if (Vactive == false) return;
        //Debug.Log(timeElapsed);
        //Debug.Log("u");
        //Vector2 NewropeLocation = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
        //RopeSpawn.transform.position = NewropeLocation;
        //public GameObject ropeclone;
        GameObject RopeClone = Instantiate(RopeParticleSpawn, RopeParticleTransform.position, RopeParticleTransform.rotation);
        RopeClone.SetActive(true);
        //Debug.Log("LLLLL");
        //RopeParticleSpawn.SetActive(true);
        //yield return new WaitForSeconds(1f);
        //RopeParticleSpawn.SetActive(false);
        
        
        //Debug.Log("new");
        
    

        
    }

    public void Vresults()
    {
        if (Vactive == false) return;

        //Debug.Log(timeElapsed);
        if (timeElapsed >= 10)
        {
            
            //SparkLocation.Translate(transform.position.x, 0,0);

            if ((heatmark.activeInHierarchy))
            {
                Vector2 NewSparkLocation = new Vector2(gameObject.transform.position.x,(gameObject.transform.position.y) + 0.55f);
                SparkLocation.transform.position = NewSparkLocation;
                Ropelocation.transform.position = NewSparkLocation;
                //Fuse.SetPosition(0, new Vector2(SparkLocation.position.x, SparkLocation.position.y));
                //yield return new WaitForSeconds(0.1f);
                timeElapsed = 0;
            }
            
            
        }
        else {
            Realscore += timeElapsed;
            timeElapsed = 0;
            
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        Vactive = true;
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {

        Vactive = true;
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {

        Vactive = false;
        
    }
}
