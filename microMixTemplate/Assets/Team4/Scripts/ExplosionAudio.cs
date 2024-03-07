using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAudio : MonoBehaviour
{
    //AudioSource AudioPlay;
    //public AudioSource AudioPlaymusic;
    public GameObject musicPlay;
    // Start is called before the first frame update
    void Start()
    {
        //AudioPlay = GetComponent<AudioSource>();
        //AudioPlay.Play(0);
        //AudioPlaymusic.PlayDelayed(2.1f);
        StartCoroutine(MusicStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MusicStart()
    {
        yield return new WaitForSeconds(1f);
        musicPlay.SetActive(true);
    }
        
    

        
    
}
