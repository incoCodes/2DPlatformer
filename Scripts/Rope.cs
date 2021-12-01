using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    // These instance variables are called to connect the rope segments to the rope class, this allows us to adjust the amount of rope segments we want accordingly,
    // this is useful if we want the rope to behave different or adjust something specific

    public Rigidbody2D hook;
    public GameObject[] prefabSegs;
    public int numlinks = 5;

    // This generates the rope's physics while using the rope segments
    void GenerateRope()
    {
        Rigidbody2D prevBod = hook;
        for(int i = 0; i < numlinks; i++)
        {
            int index = Random.Range(0, prefabSegs.Length);
            GameObject newSeg = Instantiate(prefabSegs[10]);
            newSeg.transform.parent = transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;

            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }
    }
}
