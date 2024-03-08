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
    public bool KnifeMoveActive2;
    //Vector2 up = (0,1);
    //bool Updirection;
    bool upscore;
    public FuseScript sparkStay;
    public GameObject Brokenrope1;
    public GameObject Brokenrope2;
    public GameObject Brokenrope3;
    public GameObject Brokenrope4;
    public GameObject Glow;
    public GameObject SawSound;
    

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
        KnifeMoveActive2 = true;
        //Updirection = true;
        upscore = true;
        Realscore = 0;
        Brokenrope1.SetActive(false);
        Brokenrope2.SetActive(false);
        Brokenrope3.SetActive(false);
        Brokenrope4.SetActive(false);
        Glow.SetActive(false);
        SawSound.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {

        if (Realscore == 0)
        {
            Brokenrope1.SetActive(false);
            Brokenrope2.SetActive(false);
            Brokenrope3.SetActive(false);
            //Brokenrope4.SetActive(false);


        }


        if ((Realscore >= 4) && (Realscore < 9))
        {
            Brokenrope1.SetActive(true);
            Vector2 BrokenRope1Location = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            Brokenrope1.transform.position = BrokenRope1Location;

        }

        if ((Realscore >= 9) && (Realscore < 15))
        {
            Brokenrope2.SetActive(true);
            Vector2 BrokenRope2Location = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            Brokenrope2.transform.position = BrokenRope2Location;

        }
        if ((Realscore >= 15) && (Realscore < 18))
        {
            Brokenrope3.SetActive(true);
            Vector2 BrokenRope3Location = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            Brokenrope3.transform.position = BrokenRope3Location;

        }

        if (Realscore > 25)
        {
            Brokenrope4.SetActive(true);
            Vector2 BrokenRope4Location = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            Brokenrope4.transform.position = BrokenRope4Location;
            Vactive = false;
            //bomb.SetActive(false);
            sparkStay.enabled = false;
            heatmark.SetActive(false);
            Winscore.SetActive(true);
            Music.SetActive(false);
            //Debug.Log("finish");
            
            if (endgame == true)
            {
                endgame = false;

                ReportGameCompletedEarly();
                //Debug.Log(Realscore);
                
            }
            
            //Debug.Log("finish2");
            
        }

        if (button1.IsPressed()) {
            SawSound.SetActive(true);
            if (Vactive == false) return;
            KnifeMoveActive2 = false;

            if (((Vector2)stick) == Vector2.up){
                if (RopeParticleTransform.position.y >= -3.0f)
                    {
                        TheKnifeScript.KnifeMoveActive = false;
                        if (upscore == true)
                        {
                            TheKnifeScript.KnifeVelocity = Vector3.zero;
                            timeElapsed += 1;
                            upscore = false;
                        }
                        
                        StartCoroutine(Vtimer());
                        endgame = true;

                    } 
                    else {
                        TheKnifeScript.knifespeed = 300f;
                        TheKnifeScript.KnifeMoveActive = true;
                    }


            }
            else if (((Vector2)stick) == Vector2.down){

                /*if (Updirection == false){
                    if (RopeParticleTransform.position.y >= 0.2f)
                    {



                    } 



                }*/
                if (RopeParticleTransform.position.y <= -3.4f)
                    {
                        TheKnifeScript.KnifeMoveActive = false;
                        if (upscore == false)
                        {
                            TheKnifeScript.KnifeVelocity = Vector3.zero;
                            timeElapsed += 1;
                            
                            upscore = true;
                        }
                        StartCoroutine(Vtimer());
                        endgame = true;

                    } 
                    else {
                        TheKnifeScript.knifespeed = 300f;
                        TheKnifeScript.KnifeMoveActive = true;
                    }


            }
            else 
            {
                TheKnifeScript.KnifeMoveActive = false;

            }




        }
        else{
            TheKnifeScript.KnifeMoveActive = true;
            TheKnifeScript.knifespeed = 25f;
            timeElapsed = 0;
            Realscore = 0;
            SawSound.SetActive(false);
            KnifeMoveActive2 = true;
        }

        if (timeElapsed >= 5) 
        {
            
            Vector2 NewHeatmarkLocation = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
            heatmark.transform.position = NewHeatmarkLocation;
            heatmark.SetActive(true);
            
            
        }
        else if((timeElapsed >= 1) && (timeElapsed > 5)) {
            heatmark.SetActive(false);
            //Debug.Log("hi");
           //ropeparticles();
        }
        
    }
    /*
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
        
    }*/


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


    /*
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
        
    

        
    }*/

    public void Vresults()
    {
        if (Vactive == false) return;

        //Debug.Log(timeElapsed);
        if (timeElapsed >= 12)
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
            heatmark.SetActive(false);
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
