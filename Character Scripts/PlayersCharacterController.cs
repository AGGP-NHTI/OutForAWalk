using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCharacterController : CharacterController
{
    public override void runButton(bool value)
    {
        if (value)
        {
            LOG("Run");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.runButton(value);
        }
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            LOG("Thing1");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Vertical(value);
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            LOG("Thing1");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Horizontal(value);
        }
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            LOG("Thing1");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Fire1(value);
        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
            LOG("Thing2");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Fire2(value);
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            LOG("Thing3");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Fire3(value);
        }
    }

    public override void Fire4(bool value)
    {
        if (value)
        {
            LOG("Thing4");
            PlayerPawn p = (PlayerPawn)PossesedPawn;
            p.Fire4(value);
        }
    }
}
