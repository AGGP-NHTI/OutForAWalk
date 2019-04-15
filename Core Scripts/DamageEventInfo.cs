using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEventInfo : BaseInfo
{
    public float theDamage;
    public string type;
    public bool takingDamage = false;
    public bool p1Damage = false;
    public bool p2Damage = false;
    public BaseDamageType DamageType;

    public GameObject _player1Instance;
    public GameObject _player2Instance;

    public Game g;


    public DamageEventInfo()
    {
        DamageType = new BaseDamageType();
    }

    public DamageEventInfo(Type ThisDamageType)
    {
        DamageType = (BaseDamageType)System.Activator.CreateInstance(ThisDamageType);
    }

    public void PlayerOneDamage(float d)
    {
        g._player1Instance.GetComponent<PlayerPawn>().TakeDamage(d);
    }

    public void PlayerTwoDamage(float d)
    {
        g._player2Instance.GetComponent<PlayerPawn>().TakeDamage(d);
    }
}
