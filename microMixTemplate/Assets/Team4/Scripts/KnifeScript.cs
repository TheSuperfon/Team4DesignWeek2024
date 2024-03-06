using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MicrogameInputEvents
{
    public bool movementstate;
    Vector2 KnifeDirection;

    float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        movementstate = true;
        KnifeDirection = stick.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //HorizontalTransform = Input.GetAxis("Horizontal");
        //VerticalTransform = Input.GetAxis("Vertical");
        //transform.Translate(HorizontalTransform * speed * Time.deltaTime, VerticalTransform * speed * Time.deltaTime, 0);

        



    }
}
