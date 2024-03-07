using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MicrogameInputEvents
{
    //public bool movementstate;
    Vector2 KnifeDirection;
    float knifespeed = 25f;
    float KnifeMoveFriction = 6f;
    Vector3 knifeacceleration;
    Vector3 NewKnifeLocation;
    Vector3 KnifeVelocity;
    public bool KnifeMoveActive;




    //float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //movementstate = true;
        KnifeMoveActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if joystick input is detected, but no button press:
        if (KnifeMoveActive == true)
        {
            moveknife();

        }
        

        // if button press is ever detected:
        // ActivateCutMode;



    }

    void moveknife() 
    {
        KnifeDirection = ((Vector2)stick).normalized;
        knifeacceleration = KnifeDirection * knifespeed;
        KnifeVelocity += knifeacceleration * Time.deltaTime;
        KnifeVelocity *= 1 - KnifeMoveFriction  * Time.deltaTime;

        NewKnifeLocation = transform.position + KnifeVelocity * Time.deltaTime;


        transform.position = NewKnifeLocation;
    }

    // Function to activate 'cut' mode: (pseudocode for now)
    void ActivateCutMode()
    {
        // cut mode is true. (not sure if this bool check needs to be here or in update)
        // stop horizontal movement
        // detect up/down movement only
        // if player moves up/down a certain amount, count it as 1 cut
        // else do nothing (do not add a cut)
        // if the cut count ever reaches [x] amount, set a cutSuccess variable as true, and show win state
        // on button release exit this function by setting cut mode to false, or by using return?

        // we didn't discuss it, but there should probably also be a function that makes players unable
        // to continue cutting and the game counting it if that part of the rope is now burned/gone. 

    }

}
