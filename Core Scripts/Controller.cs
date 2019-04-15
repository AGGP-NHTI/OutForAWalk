using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : BaseInfo
{
    // Base Variables
    public bool IsAI = false;
    public bool IsHuman = false;
    public bool UseSpawnSystem = true;
    public static bool LogPossessionFailures = true;
    public bool StartWithSpectator = true;

    // Prefab Spawns (No usage of "possess" etc.)
    public GameObject player1Pawn;
    public GameObject player2Pawn;

    public GameObject SpawnPoint;

    /// <summary>
    /// Player Number for Grabbing Input
    /// </summary>
    public int InputPlayerNumber = 0;

    /// <summary>
    /// Player Number in the game
    /// </summary>
    public int PlayerNumber = 0;

    // We'll enum this later 
    public int PlayerType = 1;

    protected Pawn PossesedPawn;

    protected virtual void Start()
    {
        if (!UseSpawnSystem)
        {
            return;
        }

        RequestSpawnP1(SpawnPoint.transform);
    }

    public Pawn GetPossesedPawn()
    {
        return PossesedPawn;
    }

    public virtual bool PossesPawn(Pawn p)
    {

        if (!(p.Possesed(this)))
        {
            LOG_ERROR("Controler - Possession Failure");
            return false;
        }

        // If we have a Possessed Pawn already, Call Unpossess on it. 
        if (PossesedPawn)
        {
            PossesedPawn.BecomeUnPossesed();
        }

        PossesedPawn = p;
        return true;
    }

    /// <summary>
    /// PossesPawn version taking GameObject with Pawn Script attached to it. 
    /// </summary>
    /// <param name="PawnGameObject">Game Object with Pawn Script Attached to it</param>
    /// <returns></returns>
    public virtual bool PossesPawn(GameObject PawnGameObject)
    {
        Pawn p = PawnGameObject.GetComponent<Pawn>();
        if (!p)
        {
            LOG_ERROR("GameObject " + PawnGameObject.name + " is not a pawn.");
            return false;
        }
        return PossesPawn(p);
    }

    public virtual bool UnPossesPawn(Pawn p)
    {
        p.BecomeUnPossesed();

        PossesedPawn = null;
        return true;
    }

    public GameObject RequestSpawnP1(Transform SpawnPoint)
    {
        if (!player1Pawn)
        {
            LOG_ERROR("No Player 1 Prefab Set for Spawning");
            return null;
        }

        GameObject Pawn = Factory(player1Pawn, SpawnPoint.position, SpawnPoint.rotation, this);
        PossesPawn(Pawn);
        return Pawn;
    }
}
