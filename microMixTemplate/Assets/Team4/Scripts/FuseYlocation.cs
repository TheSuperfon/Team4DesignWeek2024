using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace team04
{
	public class FuseYlocation : MonoBehaviour
{
    public float xposition;
    public Transform fuse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xposition = transform.position.x;
        if (transform.position.y != -0.28f)
        {

            Vector2 newposition = new Vector3(xposition,-2.35f);
            transform.position = newposition;

        }
    }
}



}

