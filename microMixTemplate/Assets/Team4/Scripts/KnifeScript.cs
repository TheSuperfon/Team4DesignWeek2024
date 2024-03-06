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




    //float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        //movementstate = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveknife();



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



}
