using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionControl : MonoBehaviour
{
    public float visGuyNum = 0;
    //for test purposes

    public float visRange = 5f;
    //max distance allowed in range

    public float CloseRange = 3f;
    //Close Range

    public float visAngle = 100f;
    //Angle of View

    float angle;

    public bool usePlayersOnly = true;
    //True: filter gameObjects that do not have Actor script or child of
    //False: do not filter gameObjects
    
     RaycastHit hit;

    public GameObject DEBUGTarget;
    public GameObject DEBUGHitResult;
    public bool DEBUGSameObjectBool; 

    public List<GameObject> SeenList = new List<GameObject>();

    Vector2 orig;

    //Performs a ray cast from viewing obj
    //True: LOS is blocked by another object
    //False: LOS is clear
    public bool HasLineOfSight(GameObject target)
    {
        DEBUGTarget = target;

        Vector2 rayDir = target.transform.position - gameObject.transform.position; 

        RaycastHit2D hit =
            Physics2D.Raycast(gameObject.transform.position, rayDir, visRange);
        if (hit)        //ray cast
        {
            DEBUGHitResult = hit.collider.gameObject;
            DEBUGSameObjectBool = (hit.collider.gameObject == target);
            return DEBUGSameObjectBool;
            /*
            //did I hit the target? 
            if (hit.collider.gameObject == target)
            {
                //Debug.Log(hit.collider.name);
                return true;
            }
        }
    */
        }
        return false;
 
       
    }
    
    //performs vis check and returns a list of gameObjects in LOS o viewing obj
    public List<GameObject> PerformVision()
    {
        orig = gameObject.transform.position;
        List<GameObject> hitlist = new List<GameObject>();

        // #1 Is this in Vis Range
        Collider2D[] hits = Physics2D.OverlapCircleAll(orig, visRange);     //.OverlapSphere(orig, visRange); < 3D

        //Debug.Log("Perform Vision");
        // #2 Is this an Actor? 
        foreach (Collider2D h in hits)
        {
            //Debug.Log("In Hitslist");           //Not getting here? IDK why?
            GameObject g = h.gameObject; 
            PlayerPawn a = g.GetComponentInParent<PlayerPawn>();
            if(usePlayersOnly)
            {
                if (a)
                {
                    if (!a.isDead)
                    {
                        //Debug.Log(gameObject.name + " sees " + a.gameObject.name);
                        //its an actor... hurray! '
                        // And they're alive!
                        hitlist.Add(a.gameObject);
                    }
                }
                else
                {
                   // Debug.Log(g.name + " is not an actor");
                    continue; 
                }
            }
            else 
            {             
                hitlist.Add(g);
            }

            if(g.name==gameObject.name)
            {
                hitlist.Remove(g);
            }

            // #3 is in Close range
            // if true break
            Vector3 HeadingVector = g.transform.position - gameObject.transform.position; 
            if (HeadingVector.magnitude <= CloseRange)
            {
                continue;
            }

            //or

            // #4 IS in Vis Arc
            // if false, remove from list & break 
            angle = Vector3.Angle(Vector3.forward, Vector3.right);

            // #5 Raycast LOS
            // if false, remove from list & break           
            if (!HasLineOfSight(g))
            {
                hitlist.Remove(g);
            }           
        }

        return hitlist;   
    }
}
