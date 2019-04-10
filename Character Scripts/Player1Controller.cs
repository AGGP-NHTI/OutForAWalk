using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : CharacterMovement
{
    // Variables
    public Player1Health pH;
    public Camera playerCamera;

    void Start()
    {
        inputHorizontal = "Horizontal";
        inputVertical = "Vertical";
        runButton = "RunButton";
    }
}