using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : CharacterMovement
{
    // Variables
    public Player2Health pH;

    void Start()
    {
        inputHorizontal = "Horizontal2";
        inputVertical = "Vertical2";
        runButton = "RunButton2";
    }
}
