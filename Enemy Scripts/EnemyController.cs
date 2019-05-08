using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyActor
{
   
    public delegate void ThinkFunction();
    public ThinkFunction think;

    public bool LOSCheck;
    public string STATEName;
    public float DistanceSeenGO; 
    public bool HasEnteredState = false;

    //If AI shoots at player after seeing them, follows player but maintains certain distance
    public float visonAngle = 90f;
    public float visonRange = 5f;
    public float outOfVisionRange = 10f;
    public bool isShooter = false;
    public float shootRange = 5;
    public float SpawnDistance = .25f; 
    float distanceToSeenGO;

    
    float shootTimer = 0f;
    public float shootRate = 2f;
    public bool CanShoot = true; 


    public bool useActorsOnly = true;

    public GameObject SeenPlayerGO; // Game Object
    public Pawn SeenPlayerPawn; // Pawn Object
    Vector2 shootPos;
    public GameObject shootPreFab;

    public float speed;
    public float SDistance;

    public float waitTime;
    public float startWaitTime;

    public Transform[] PathPoints;
    private int PathPointIndex = 0;

    private GameObject target;

    VisionControl vc;
    public List<GameObject> SeenList;  
    

    protected void Start()
    {
        vc = gameObject.GetComponent<VisionControl>();
        vc.visAngle = visonAngle;
        vc.visRange = visonRange;

        waitTime = startWaitTime;

        SetState(ThinkPatrol); 
    }


    protected void FixedUpdate()
    {
        if (think != null)
        {
            think.Invoke(); 
        }

    }


    public void SetState (ThinkFunction newthink)
    {
        HasEnteredState = true;
        think = newthink; 
    }

    public void ThinkPatrol()
    {
        if (HasEnteredState)
        {
            STATEName = "Patrol";
            HasEnteredState = false;
        }

        UpdatePatrol();

        // vison control sees a playerpawn object
        SeenList = vc.PerformVision();
        foreach (GameObject g in SeenList)
        {
            PlayerPawn pawn = g.GetComponentInParent<PlayerPawn>();

            if (pawn)
            {
                SeenPlayerPawn = pawn; 
                SeenPlayerGO = g; 
                SetState(ThinkSee);
                return; 
            }
        }
    }

    //Manages the patrol 
    public void UpdatePatrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, PathPoints[PathPointIndex].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, PathPoints[PathPointIndex].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
               // Debug.Log("moving...");
                PathPointIndex++;
                waitTime = startWaitTime;
                if (PathPointIndex >= PathPoints.Length)
                {
                    PathPointIndex = 0;
                }
            }
            else
            {
               // Debug.Log("waiting...");
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void ThinkSee()
    {
        //Debug.Log("ThinkSee State");
        if (HasEnteredState)
        {
            STATEName = "See";
            HasEnteredState = false;
        }
        // If We have no Seen Player, return to Patrol 
        if (SeenPlayerGO == null)
        {
            SetState(ThinkPatrol);
        }

        MoveToPlayer();

        //Check LOS
        // if Lost LOS, return to Patrol
        // SeenPlayer = null; 

        distanceToSeenGO = Vector2.Distance(transform.position, SeenPlayerGO.transform.position);

        DistanceSeenGO = distanceToSeenGO;

        // check vision Range
        // if out of range,  return to Patrol

        if (distanceToSeenGO > outOfVisionRange)
        {
            Debug.Log("I dont see player anymore");
            SeenPlayerGO = null;
            SeenPlayerPawn = null;
            SetState(ThinkPatrol);
            return;
        }

        Debug.Log("I still see player");

        // if is a shooter 
        // if in shoot range
        // go to ThinkShoot; 

        if (isShooter)
        {
            Debug.Log("I am a shooter!");
            if (distanceToSeenGO < shootRange)
            {
                Debug.Log("Getting ready to shoot!");
                SetState(ThinkShoot);
                return;
            }
        }
    }

    //****TO DO  TO DO  TO DO****
    // Manages anything related to moving to the player... 
    public void MoveToPlayer()
    {
        Debug.Log("Moving toward player");
        transform.position = Vector2.MoveTowards(transform.position, SeenPlayerGO.transform.position, speed * Time.deltaTime);
    }

    public void ThinkShoot()
    {
        Debug.Log("ThinkShoot State");

        if (HasEnteredState)
        {
            STATEName = "Shoot";
            HasEnteredState = false;
        }
        // If We have no Seen Player, return to Patrol 
        if (SeenPlayerGO == null)
        {
            SetState(ThinkPatrol);
        }

        //Check LOS
        // if Lost LOS, return to Patrol
        // SeenPlayer = null; 
        //if (!vc.HasLineOfSight(SeenPlayerGO))
        //{
        //    SeenPlayerGO = null;
        //    SeenPlayerPawn = null;
        //    SetState(ThinkPatrol);
        //    return;
        //}
        distanceToSeenGO = Vector2.Distance(transform.position, SeenPlayerGO.transform.position);

        DistanceSeenGO = distanceToSeenGO;



        if (distanceToSeenGO >= shootRange)
        {
            Debug.Log("I don't see anyone anymore...");
            SetState(ThinkPatrol);
            return;
        }

        //****TO DO  TO DO  TO DO****
        // check shoot Range
        // if in range, shoot
        // Else return to ThinkSee
        if (distanceToSeenGO <= shootRange)
        {
            Shoot();
        }
        else
        {
            SetState(ThinkSee);
        }
    }

    
    protected void Shoot()
    {
        if (CanShoot)
        { 


        Vector3 DirVect = (SeenPlayerGO.transform.position - gameObject.transform.position).normalized;
        //   float angle = (Mathf.Rad2Deg * Mathf.Atan2(DirVect.y, DirVect.x));
        // Vector3 vRotation = new Vector3(0, 0, angle);
        //Quaternion qRotation = Quaternion.Euler(vRotation);

        shootPos = gameObject.transform.position + (SpawnDistance * DirVect);

        GameObject newObj = Instantiate(shootPreFab, shootPos, Quaternion.identity);
        BulletScript bs = newObj.GetComponent<BulletScript>();
        bs.moveDir = DirVect;
            //bs.rb.velocity = (DirVect * bs.moveSpeed);     

            //****TO DO  TO DO  TO DO****
            // Set Projectile move at player
            CanShoot = false;
        } 
        else
        {
            shootTimer += Time.deltaTime; 
            if (shootTimer > shootRate)
            {
                CanShoot = true;
                shootTimer = 0; 
            }
        }
    }

    /*
    protected void FixedUpdate_old()

    {
        if (true)
        {
            if(movespot.Length==0)
            {
                Debug.Log("No movepoints, i'll just stay here...");
                return;
            }
            transform.position = Vector2.MoveTowards(transform.position, movespot[random].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, movespot[random].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    random = Random.Range(0, movespot.Length);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }

        SeenList = vc.PerformVision();
        foreach (GameObject g in SeenList)
        {
            Actor a = g.GetComponentInParent<Actor>();

            if (a)
            {
                isPatrolling = false;

                Debug.Log("***" + gameObject.name + " found (m) " + g.name);
                target = g.GetComponent<Transform>();

                if(isFollowerAI)
                {
                    if (Vector2.Distance(transform.position, target.position) > SDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    }
                }
                else if(isShooterAI)
                {
                    timer += Time.deltaTime;

                    if (timer >= shootRate)
                    {
                        Shoot();
                        timer = 0;
                    }

                    if (Vector2.Distance(transform.position, target.position) > SDistance)      //adjust so shooter follows but maintains certain distance
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    }
                }
            }
        }
        
    }
    */

}