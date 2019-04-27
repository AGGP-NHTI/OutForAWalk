using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimator : MonoBehaviour
{
    // Player Pawn
    PlayerPawn PP;


    /// Sprites In-Use DO NOT EDIT THESE
    public Sprite idleNorth;
    public Sprite idleSouth;
    public Sprite idleEast;
    public Sprite idleWest;
    public Sprite moveNorth;
    public Sprite moveSouth;
    public Sprite moveEast;
    public Sprite moveWest;
    public Sprite attackNorth;
    public Sprite attackSouth;
    public Sprite attackEast;
    public Sprite attackWest;





    /// Idle Sprites (Owner)
    public Sprite idleNorthOwner;
    public Sprite idleSouthOwner;
    public Sprite idleEastOwner;
    public Sprite idleWestOwner;

    /// Movement Sprites (Owner)
    public Sprite moveNorthOwner;
    public Sprite moveSouthOwner;
    public Sprite moveEastOwner;
    public Sprite moveWestOwner;

    /// Attack Sprites (Owner)
    public Sprite attackNorthOwner;
    public Sprite attackSouthOwner;
    public Sprite attackEastOwner;
    public Sprite attackWestOwner;





    /// Idle Sprites (Pet)
    public Sprite idleNorthPet;
    public Sprite idleSouthPet;
    public Sprite idleEastPet;
    public Sprite idleWestPet;

    /// Movement Sprites (Pet)
    public Sprite moveNorthPet;
    public Sprite moveSouthPet;
    public Sprite moveEastPet;
    public Sprite moveWestPet;

    /// Attack Sprites (Pet)
    public Sprite attackNorthPet;
    public Sprite attackSouthPet;
    public Sprite attackEastPet;
    public Sprite attackWestPet;




    void Awake()
    {
        PP = gameObject.GetComponent<PlayerPawn>();
    }




    void Update()
    {
        




        if (PP.isOwner)
        {
            idleNorth = idleNorthOwner;
            idleSouth = idleSouthOwner;
            idleEast = idleEastOwner;
            idleWest = idleWestOwner;
            moveNorth = moveNorthOwner;
            moveSouth = moveSouthOwner;
            moveEast = moveEastOwner;
            moveWest = moveWestOwner;
            attackNorth = attackNorthOwner;
            attackSouth = attackSouthOwner;
            attackEast = attackEastOwner;
            attackWest = attackWestOwner;
        }

        if (PP.isPet)
        {
            idleNorth = idleNorthPet;
            idleSouth = idleSouthPet;
            idleEast = idleEastPet;
            idleWest = idleWestPet;
            moveNorth = moveNorthPet;
            moveSouth = moveSouthPet;
            moveEast = moveEastPet;
            moveWest = moveWestPet;
            attackNorth = attackNorthPet;
            attackSouth = attackSouthPet;
            attackEast = attackEastPet;
            attackWest = attackWestPet;
        }

        


    }
}
