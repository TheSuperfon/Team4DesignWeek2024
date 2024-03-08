using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerboaAnimationPlayer : MonoBehaviour
{
    public Animator JerboaAnim;
    // Start is called before the first frame update
    void Start()
    {
        JerboaAnim.Play("Jerboa");

        StartCoroutine(JerboaIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator JerboaIdle()
    {
        yield return new WaitForSeconds(18f); 
        JerboaAnim.Play("Jerboa2");

        
    }
}
