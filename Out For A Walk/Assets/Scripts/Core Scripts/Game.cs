using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : BaseInfo
{
    // Spawn Points
    public GameObject OwnerSpawn;
    public GameObject PetSpawn;

    // Player Pawn (to switch camera when owner changes)
    public PlayerPawn PP1;
    public PlayerPawn PP2;

    // Player Prefab
    public GameObject player1Spawn;
    public GameObject player2Spawn;

    // Camera Control
    public Camera mainCamera;
    private Vector3 offset;
    GameObject cameraFocus;

    // Instances
    public GameObject _player1Instance;
    public GameObject _player2Instance;

    // Placeholder (when character dies, to prevent errors)
    public GameObject placeholderCharacter;

    public void Awake()
    {
        // Player 1 Spawn
        _player1Instance = Instantiate(player1Spawn);
        _player1Instance.gameObject.name = "Player1";
        PP1 = _player1Instance.GetComponent<PlayerPawn>();

        // Player 2 Spawn
        _player2Instance = Instantiate(player2Spawn);
        _player2Instance.gameObject.name = "Player2";
        PP2 = _player2Instance.GetComponent<PlayerPawn>();
    }

    void Start()
    {
        offset = mainCamera.transform.position - _player1Instance.transform.position;

        _player1Instance.transform.position = player1Spawn.transform.position;
        _player2Instance.transform.position = player2Spawn.transform.position;
    }

    void Update()
    {
        if (!_player1Instance || _player1Instance == placeholderCharacter)
        {
            _player1Instance = _player2Instance;
        }

        if (PP1.isOwner)
        {
            cameraFocus = _player1Instance;
        }

        if (PP2.isOwner)
        {
            cameraFocus = _player2Instance;
        }

        // Adds a "spectator" object there, preventing errors
        if (!_player1Instance)
        {
            _player1Instance = placeholderCharacter;
        }

        if (!_player2Instance)
        {
            _player2Instance = placeholderCharacter;
        }

        mainCamera.transform.position = cameraFocus.transform.position + offset;
    }
}
