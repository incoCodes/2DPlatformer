using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject[] prefabSegs;
    public int numlinks = 5;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
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
