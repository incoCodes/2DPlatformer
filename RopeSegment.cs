using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    // These instance variables are to check if the player is attached to the rope segment which is one individual section of the rope split into 5 sections
    public GameObject connectedAbove, connectedBelow;
    public bool isPlayerAttached;
   
    // This fixes the anchor of the rope segment once the player is attached to it, this is so that the player and the segment are parallel to each other rather so we don't get any problems applying physics
    public void RestAnchor()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        RopeSegment aboveSegment = connectedAbove.GetComponent<RopeSegment>();
        if (aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, spriteBottom * -1);
        }
         else
        {
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
