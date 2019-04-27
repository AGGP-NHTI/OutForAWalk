using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : BaseInfo
{
    // Spawn Points
    public GameObject OwnerSpawn;
    public GameObject PetSpawn;

    // Player Prefab
    public GameObject player1Spawn;
    public GameObject player2Spawn;

    // Camera Control
    public Camera mainCamera;
    private Vector3 offset;

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

        // Player 2 Spawn
        _player2Instance = Instantiate(player2Spawn);
        _player2Instance.gameObject.name = "Player2";
    }

    void Start()
    {
        offset = mainCamera.transform.position - _player1Instance.transform.position;

        _player1Instance.transform.position = player1Spawn.transform.position;
        _player2Instance.transform.position = player2Spawn.transform.position;
    }

    void Update()
    {
        if (!_player1Instance)
        {
            _player1Instance = _player2Instance;
        }

        // Adds a "spectator" object there
        if (!_player1Instance)
        {
            _player1Instance = placeholderCharacter;
        }

        if (!_player2Instance)
        {
            _player2Instance = placeholderCharacter;
        }
    }

    void LateUpdate()
    {
        mainCamera.transform.position = _player1Instance.transform.position + offset;
    }
}
