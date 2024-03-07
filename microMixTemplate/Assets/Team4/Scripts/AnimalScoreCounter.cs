using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimalScoreCounter : MicrogameInputEvents
{
    public TextMeshProUGUI AnimalCounterText;
    public float AnimalCounter;
    // Start is called before the first frame update
    void Start()
    {
        AnimalCounter = 1;
        AnimalCounterText.text = AnimalCounter.ToString();
;



    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AnimalCounterText.text = AnimalCounter.ToString();
        //Debug.Log("Fix");
    }
}
