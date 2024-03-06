using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        StartCoroutine(ropeparticles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator ropeparticles()
    {
        //if (Vactive == false) return;
        //Debug.Log(timeElapsed);
        //Debug.Log("log");
        //Vector2 NewropeLocation = new Vector2((gameObject.transform.position.x - 0.4f),(gameObject.transform.position.y + 0.55f));
        //RopeSpawn.transform.position = NewropeLocation;
        //public GameObject ropeclone;
        //Instantiate(RopeParticleSpawn, gameObject.transform);
        //RopeParticleSpawn.SetActive(true);
        yield return new WaitForSeconds(1f);
        //RopeParticleSpawn.SetActive(false);
        Destroy(gameObject);
        
        
        //Debug.Log("new");
        
    

        
    }
}
